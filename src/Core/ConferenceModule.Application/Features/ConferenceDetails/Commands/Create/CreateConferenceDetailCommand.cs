using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Create;

public class CreateConferenceDetailCommand : IRequest<ConferenceDetail> {
    public Guid ConferenceId { get; set; }
    public Guid? GuestId { get; set; }
    public Guid AccountId { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public int? ModifiedBy { get; set; }
    public ConferenceDetailStatus Status { get; set; }
}