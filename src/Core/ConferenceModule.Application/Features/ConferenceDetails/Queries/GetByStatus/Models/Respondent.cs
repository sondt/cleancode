namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;

public class Respondent {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Title { get; set; }
}