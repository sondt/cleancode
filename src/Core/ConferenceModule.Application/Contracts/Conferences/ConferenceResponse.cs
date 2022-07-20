using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Contracts.Conferences;

public class ConferenceResponse {
    public Guid Id { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public DateTime? PublishedDate { get; set; }
    public DateTime ModifiedDate { get; set; }
    public ConferenceDetailStatus Status { get; set; }
    public Questioner? Questioner { get; set; }
    public Respondent? Respondent { get; set; }
}