using System.ComponentModel.DataAnnotations.Schema;
using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Domain;

public class Conference {
    public Guid Id { get; set; }

    [Column("NewsId")]
    public long ArticleId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ConferenceStatus Status { get; set; }
    public IEnumerable<ConferenceGuest>? ConferenceGuests { get; set; }
    public Article? Article { get; set; }

    public IEnumerable<ConferenceDetail>? ConferenceDetails { get; set; }

    public IEnumerable<ConferencePermission>? ConferencePermissions { get; set; }
}