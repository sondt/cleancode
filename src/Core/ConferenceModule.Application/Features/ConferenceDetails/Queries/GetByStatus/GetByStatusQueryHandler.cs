using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus;

[SuppressMessage("ReSharper", "ComplexConditionExpression")]
public class GetByStatusQueryHandler : IRequestHandler<GetByStatusQuery, PagedResult<QuestionAnswerDto>> {
    private readonly IRepositoryBase<ConferenceDetail> _conferenceDetailRepositoryBase;
    private readonly IMapper _mapper;

    public GetByStatusQueryHandler(IRepositoryBase<ConferenceDetail> repository, IMapper mapper) {
        _conferenceDetailRepositoryBase = repository;
        _mapper = mapper;
    }


    public async Task<PagedResult<QuestionAnswerDto>> Handle(GetByStatusQuery request,
        CancellationToken cancellationToken) {
        var query = _conferenceDetailRepositoryBase.FindByCondition(conference =>
                conference.Status == request.Status &&
                conference.Conference!.ConferencePermissions!.Any(p => p.UserId == request.UserId))
            .Where(conference => conference.ConferenceId == request.ConferenceId);

        if (request.Status != ConferenceDetailStatus.WaitingEdit)
            query = query.Where(o => o.Conference!.ConferencePermissions!.Any(p =>
                p.Role == ConferencePermissionRole.Manager || p.Role == ConferencePermissionRole.Publisher));
        else
            query = query.Where(o => o.EditorId == request.UserId || o.Conference!.ConferencePermissions!.Any(p =>
                p.Role == ConferencePermissionRole.Manager || p.Role == ConferencePermissionRole.Publisher));
        return await query.OrderBy(conference => conference.ModifiedDate)
            .ProjectTo<QuestionAnswerDto>(_mapper.ConfigurationProvider).GetPaged(request.PageIndex, request.PageSize);
    }
}