using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Commands.Create;

public class CreateGuestCommand : IRequest<Guest> {
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Avatar { get; set; }
    public int CreatedBy { get; set; }
    public Status Status { get; set; }
}