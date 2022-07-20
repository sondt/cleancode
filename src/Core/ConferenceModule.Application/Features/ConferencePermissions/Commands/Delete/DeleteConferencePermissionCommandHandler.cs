using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferencePermissions.Commands.Delete;

public class DeleteConferencePermissionCommandHandler : IRequestHandler<DeleteConferencePermissionCommand, int> {
    private readonly IRepositoryBase<ConferencePermission> _repository;

    public DeleteConferencePermissionCommandHandler(IRepositoryBase<ConferencePermission> repository) {
        _repository = repository;
    }

    public async Task<int> Handle(DeleteConferencePermissionCommand request, CancellationToken cancellationToken) {
        var conferencePermission = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (conferencePermission == null)
            throw new NotFoundException(nameof(ConferencePermission), request.Id.ToString());
        return await _repository.DeleteAsync(conferencePermission, cancellationToken);
    }
}