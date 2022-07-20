using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Update;

public class UpdateConferenceDetailCommand : IRequest<ConferenceDetail> {
    public Guid Id { get; set; }
    public Guid? GuestId { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public int ModifiedBy { get; set; }
    public ConferenceDetailStatus Status { get; set; }

    public void SetId(Guid id) {
        Id = id;
    }
}