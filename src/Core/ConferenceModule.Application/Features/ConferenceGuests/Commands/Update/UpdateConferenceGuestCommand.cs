using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Update;

public class UpdateConferenceGuestCommand : IRequest<ConferenceGuest> {
    public Guid Id { get; private set; }
    public Guid ConferenceId { get; set; }
    public Guid GuestId { get; set; }

    public void SetId(Guid id) {
        Id = id;
    }
}