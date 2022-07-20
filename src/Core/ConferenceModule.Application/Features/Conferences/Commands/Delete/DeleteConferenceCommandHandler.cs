using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Delete;

public class DeleteConferenceCommandHandler : IRequestHandler<DeleteConferenceCommand, int> {
    private readonly IConferenceRepository _conferenceRepository;

    public DeleteConferenceCommandHandler(IConferenceRepository conferenceRepository) {
        _conferenceRepository = conferenceRepository;
    }

    public async Task<int> Handle(DeleteConferenceCommand request, CancellationToken cancellationToken) {
        var existed = await _conferenceRepository.GetAsync(new BaseRequest(request.Id, cancellationToken));
        if (existed == null) throw new NotFoundException(request.Id, nameof(Conference));
        return await _conferenceRepository.DeleteAsync(existed, cancellationToken);
    }
}