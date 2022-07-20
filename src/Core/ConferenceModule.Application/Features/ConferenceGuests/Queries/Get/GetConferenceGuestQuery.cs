using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Queries.Get;

public class GetConferenceGuestQuery : IRequest<ConferenceGuest?> {
    public Guid Id { get; set; }
}