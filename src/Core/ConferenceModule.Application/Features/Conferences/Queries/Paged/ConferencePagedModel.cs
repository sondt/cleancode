using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Queries.Paged;

public class ConferencePagedModel {
    public Guid Id { get; set; }
    public string? ArticleId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string? Title { get; set; }
    public string? Avatar { get; set; }
    public ConferenceStatus Status { get; set; }
    public int GuestCount { get; set; }
    public int EditorCount { get; set; }
    public int QuestionCount { get; set; }
}