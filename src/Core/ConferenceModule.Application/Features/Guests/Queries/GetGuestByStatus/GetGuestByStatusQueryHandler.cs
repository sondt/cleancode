using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Queries.GetGuestByStatus;

public class GetGuestByStatusQueryHandler : IRequestHandler<GetGuestByStatusQuery, PagedResult<Guest>> {
    private readonly IRepositoryBase<Guest> _repository;

    public GetGuestByStatusQueryHandler(IRepositoryBase<Guest> repository) {
        _repository = repository;
    }

    public async Task<PagedResult<Guest>> Handle(GetGuestByStatusQuery request, CancellationToken cancellationToken) {
        return await _repository
            .FindByCondition(guest => (request.Status == Status.All || guest.Status == request.Status) &&
                                      (string.IsNullOrEmpty(request.Keyword) || guest.Name!.Contains(request.Keyword) ||
                                       guest.Title!.Contains(request.Keyword))).OrderBy(guest => guest.Name)
            .GetPaged(request.PageIndex, request.PageSize);
    }
}