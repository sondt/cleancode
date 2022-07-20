using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Delete;

public class DeleteConferenceGuestCommand : IRequest<int> {
    public Guid Id { get; set; }
}