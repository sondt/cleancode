namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;

public class Questioner {
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string? UserName { get; set; }
}