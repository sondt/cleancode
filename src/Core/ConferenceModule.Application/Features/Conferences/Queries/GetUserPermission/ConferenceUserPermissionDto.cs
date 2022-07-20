using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetUserPermission;

public class ConferenceUserPermissionDto {
    public Guid ConferencePermissionId { get; set; }
    public int UserId { get; set; }
    public ConferencePermissionRole Role { get; set; }
    public string? UserName { get; set; }
    public string? FullName { get; set; }
}