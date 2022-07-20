using ConferenceModule.Domain.BaseModels;
using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Domain;

public class ConferenceDetail : BaseEntity {
    public Guid Id { get; set; }
    public Guid ConferenceId { get; set; }
    public Guid? GuestId { get; set; }
    public Guid? AccountId { get; set; }
    public string? Question { get; set; }
    public string? Answer { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? PublishedDate { get; set; }
    public int? PublishedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public int? ModifiedBy { get; set; }

    public int? EditorId { get; set; }
    public ConferenceDetailStatus Status { get; set; }
    public Conference? Conference { get; set; }
    public Account? Account { get; set; }
    public Guest? Guest { get; set; }

    public User? Editor { get; set; }
}