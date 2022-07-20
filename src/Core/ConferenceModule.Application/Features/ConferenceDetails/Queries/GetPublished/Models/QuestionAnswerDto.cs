namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished.Models;

public class QuestionAnswerDto {
    public Guid Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? PublishedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public Questioner? Questioner { get; set; }
    public Respondent? Respondent { get; set; }
}