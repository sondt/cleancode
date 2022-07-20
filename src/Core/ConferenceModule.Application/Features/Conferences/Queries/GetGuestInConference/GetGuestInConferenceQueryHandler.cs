using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;

public class
    GetGuestInConferenceQueryHandler : IRequestHandler<GetGuestInConferenceQuery, IReadOnlyList<GuestInConferenceDto>
        ?> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceGuest> _repository;

    public GetGuestInConferenceQueryHandler(IRepositoryBase<ConferenceGuest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<GuestInConferenceDto>?> Handle(GetGuestInConferenceQuery request,
        CancellationToken cancellationToken) {
        return await _repository
            .FindByCondition(conference => conference.Guest!.Status == Status.Active &&
                                           (conference.Conference!.Id == request.ConferenceId ||
                                            conference.Conference!.ArticleId == request.ArticleId))
            .OrderBy(conference => conference.Guest!.Name)
            .ProjectTo<GuestInConferenceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}