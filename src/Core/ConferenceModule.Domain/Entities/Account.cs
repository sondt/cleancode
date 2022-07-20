using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Domain;

public class Account {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public Sex Sex { get; set; }
    public string? Passport { get; set; }
    public string? Address { get; set; }
    public bool VerifiedEmail { get; set; }
    public bool VerifiedPhone { get; set; }
    public string? OtpKey { get; set; }
    public bool OtpStatus { get; set; }
    public AccountType AccountType { get; set; }
    public string? ThirdPartyId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public DateTime? LastChangePassword { get; set; } = DateTime.Now;
    public AccountStatus Status { get; set; }
}