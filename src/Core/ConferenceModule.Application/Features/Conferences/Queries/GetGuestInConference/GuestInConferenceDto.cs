namespace ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;

public class GuestInConferenceDto {
    public Guid ConferenceGuestId { get; set; }
    public Guid GuestId { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public string? Avatar { get; set; }
}