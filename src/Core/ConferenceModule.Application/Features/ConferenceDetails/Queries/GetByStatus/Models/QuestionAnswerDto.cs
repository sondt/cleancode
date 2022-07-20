using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;

public class QuestionAnswerDto {
    public Guid Id { get; set; }
    public Guid GuestId { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? PublishedDate { get; set; }
    public int? PublishedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }
    public int? EditorId { get; set; }
    public ConferenceDetailStatus Status { get; set; }
    public string? EditorName { get; set; }
    public Questioner? Questioner { get; set; }
    public Respondent? Respondent { get; set; }
}