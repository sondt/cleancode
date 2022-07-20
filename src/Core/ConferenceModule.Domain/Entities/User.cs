using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceModule.Domain; 

[Table("User")]
public class User {
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
    public string? Avatar { get; set; }
    public string? Password { get; set; }
    public string? OtpKey { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public byte? IsActive { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? LastChangePass { get; set; }
    public int? UserType { get; set; }
    public string? ThirdPartyId { get; set; }
    public DateTime? Bod { get; set; }
    public string? Passpost { get; set; }
    public int? Sex { get; set; }
    public string? UserTitle { get; set; }
    public string? MachineKey { get; set; }
    public string? MachineKey2 { get; set; }
}