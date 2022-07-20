using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Commands.Update;

public class UpdateConferenceModel {
    public Guid Id { get; set; }
    public long NewsId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ConferenceStatus Status { get; set; }
}