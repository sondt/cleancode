using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished.Models;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished;

[SuppressMessage("ReSharper", "ComplexConditionExpression")]
public class GetByStatusQueryHandler : IRequestHandler<GetByStatusQuery, IReadOnlyCollection<QuestionAnswerDto>> {
    private readonly IRepositoryBase<ConferenceDetail> _conferenceDetailRepositoryBase;
    private readonly IMapper _mapper;

    public GetByStatusQueryHandler(IRepositoryBase<ConferenceDetail> repository, IMapper mapper) {
        _conferenceDetailRepositoryBase = repository;
        _mapper = mapper;
    }


    public async Task<IReadOnlyCollection<QuestionAnswerDto>> Handle(GetByStatusQuery request,
        CancellationToken cancellationToken) {
        var query = _conferenceDetailRepositoryBase
            .FindByCondition(conference => conference.Status == ConferenceDetailStatus.Published)
            .Where(conference => conference.ConferenceId == request.ConferenceId);

        return await query.OrderBy(conference => conference.PublishedDate)
            .ProjectTo<QuestionAnswerDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}