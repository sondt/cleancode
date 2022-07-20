using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.UpdateStatus;

public class UpdateStatusConferenceDetailCommand : IRequest<bool> {
    public Guid Id { get; set; }
    public ConferenceDetailStatus Status { get; set; }

    public int ModifiedBy { get; set; }

    public int? EditorId { get; set; }
}