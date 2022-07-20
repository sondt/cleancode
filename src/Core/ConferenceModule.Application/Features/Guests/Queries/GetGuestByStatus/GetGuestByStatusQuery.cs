using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Queries.GetGuestByStatus;

public class GetGuestByStatusQuery : FindBaseModel, IRequest<PagedResult<Guest>> {
    public Status Status { get; set; }
}