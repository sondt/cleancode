using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.Get;

public class GetConferenceQueryHandler : IRequestHandler<GetConferenceQuery, GetConferenceModel?> {
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IMapper _mapper;

    public GetConferenceQueryHandler(IConferenceRepository conferenceRepository, IMapper mapper) {
        _conferenceRepository = conferenceRepository;
        _mapper = mapper;
    }

    public async Task<GetConferenceModel?> Handle(GetConferenceQuery request, CancellationToken cancellationToken) {
        if (request.Id == null) throw new ArgumentNullException(nameof(request.Id));
        var onlineExchange = await _conferenceRepository.GetAsync(new BaseRequest(request.Id, cancellationToken));
        if (onlineExchange == null)
            throw new NotFoundException(nameof(Conference), request.Id.ToString());
        return _mapper.Map<GetConferenceModel>(onlineExchange);
    }
}