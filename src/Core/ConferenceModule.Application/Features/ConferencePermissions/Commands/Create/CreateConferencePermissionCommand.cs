using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferencePermissions.Commands.Create;

public class CreateConferencePermissionCommand : IRequest<ConferencePermission> {
    public Guid? ConferenceId { get; set; }
    public int UserId { get; set; }
    public ConferencePermissionRole Role { get; set; }
}