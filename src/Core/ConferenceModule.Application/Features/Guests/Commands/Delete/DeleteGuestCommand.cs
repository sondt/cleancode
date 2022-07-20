using MediatR;

namespace ConferenceModule.Application.Features.Guests.Commands.Delete;

public class DeleteGuestCommand : IRequest<int> {
    public Guid Id { get; set; }
}