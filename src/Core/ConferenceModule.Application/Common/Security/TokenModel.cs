namespace ConferenceModule.Application.Common.Security;

public class TokenModel {
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }

    public Role Role { get; set; }
}