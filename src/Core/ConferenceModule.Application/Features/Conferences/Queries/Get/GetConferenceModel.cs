using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Queries.Get;

public class GetConferenceModel {
    public Guid Id { get; set; }
    public long NewsId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ConferenceStatus Status { get; set; }
}