using System.ComponentModel.DataAnnotations;

namespace ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;

public class RefreshTokenRequest {
    [Required]
    public string? ExpiredToken { get; set; }

    [Required]
    public string? RefreshToken { get; set; }
}