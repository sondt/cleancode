using System.ComponentModel.DataAnnotations;

namespace ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;

public class AuthenticationRequest {
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    // public string? ReturnUrl { get; set; }
    //
    // public bool RememberMe { get; set; }
    //
    // public string? IpAddress { get; set; }
}