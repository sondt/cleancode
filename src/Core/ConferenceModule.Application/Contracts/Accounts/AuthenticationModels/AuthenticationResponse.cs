namespace ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;

public class AuthenticationResponse {
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
}