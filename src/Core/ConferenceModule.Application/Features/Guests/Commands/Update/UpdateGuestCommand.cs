using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Commands.Update;

public class UpdateGuestCommand : IRequest<Guest> {
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Avatar { get; set; }
    public int ModifiedBy { get; set; }
    public Status Status { get; set; }
}