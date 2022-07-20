using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.UpdateStatus;

public class UpdateStatusConferenceDetailCommandHandler : IRequestHandler<UpdateStatusConferenceDetailCommand, bool> {
    private readonly IRepositoryBase<ConferenceDetail> _repository;

    public UpdateStatusConferenceDetailCommandHandler(IRepositoryBase<ConferenceDetail> repository) {
        _repository = repository;
    }

    public async Task<bool> Handle(UpdateStatusConferenceDetailCommand request, CancellationToken cancellationToken) {
        if (request.ModifiedBy <= 0) throw new BadRequestException(ValidateMessage.InvalidUser);

        var conferenceDetail = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (conferenceDetail == null) throw new NotFoundException(nameof(ConferenceDetail), request.Id.ToString());

        if (request.Status is ConferenceDetailStatus.Deleted or ConferenceDetailStatus.Published
            or ConferenceDetailStatus.WaitingPublish)
            conferenceDetail.EditorId = null;

        if (request.EditorId > 0)
            conferenceDetail.EditorId = request.EditorId;

        conferenceDetail.ModifiedDate = DateTime.Now;
        conferenceDetail.ModifiedBy = request.ModifiedBy;

        if (request.Status == ConferenceDetailStatus.Published) {
            if (conferenceDetail.Status != ConferenceDetailStatus.Published)
                conferenceDetail.PublishedDate = DateTime.Now;
            conferenceDetail.PublishedBy = request.ModifiedBy;
        }

        conferenceDetail.Status = request.Status;
        await _repository.UpdateAsync(conferenceDetail, cancellationToken);

        return true;
    }
}