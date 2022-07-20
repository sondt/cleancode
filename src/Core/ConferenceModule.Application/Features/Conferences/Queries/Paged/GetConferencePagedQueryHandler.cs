using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.Paged;

public class
    GetConferencePagedQueryHandler : IRequestHandler<GetConferencePagedQuery, PagedResult<ConferencePagedModel>> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Conference> _repository;

    public GetConferencePagedQueryHandler(IRepositoryBase<Conference> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResult<ConferencePagedModel>> Handle(GetConferencePagedQuery request,
        CancellationToken cancellationToken) {
        return await _repository.FindByCondition(conference => conference.EndTime > DateTime.Now)
            .OrderByDescending(conference => conference.Article!.PublishedDate)
            .ProjectTo<ConferencePagedModel>(_mapper.ConfigurationProvider)
            .GetPaged(request.PageIndex, request.PageSize);
    }
}