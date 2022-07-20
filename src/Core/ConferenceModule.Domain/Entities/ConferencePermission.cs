using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Domain;

public class ConferencePermission {
    public Guid Id { get; set; }
    public Guid? ConferenceId { get; set; }
    public int UserId { get; set; }
    public ConferencePermissionRole Role { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public User User { get; set; } = null!;

    public Conference Conference { get; set; } = null!;
}