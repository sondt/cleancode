using MediatR;

namespace ConferenceModule.Application.Features.ConferencePermissions.Commands.Delete;

public class DeleteConferencePermissionCommand : IRequest<int> {
    public Guid Id { get; set; }
}