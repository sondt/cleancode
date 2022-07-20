using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetUserPermission;

public class GetUserPermissionQuery : IRequest<IReadOnlyList<ConferenceUserPermissionDto>> {
    public Guid ConferenceId { get; set; }
}