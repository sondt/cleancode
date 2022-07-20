using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Create;

public class CreateConferenceGuestCommand : IRequest<ConferenceGuest> {
    public Guid ConferenceId { get; set; }
    public Guid GuestId { get; set; }
}