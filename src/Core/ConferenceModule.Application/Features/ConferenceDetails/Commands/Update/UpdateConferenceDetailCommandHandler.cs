using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Update;

public class UpdateConferenceDetailCommandHandler : IRequestHandler<UpdateConferenceDetailCommand, ConferenceDetail> {
    private readonly IConferenceDetailRepository _conferenceDetailRepository;
    private readonly IConferenceHub _conferenceHub;
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceDetail> _repository;

    // ReSharper disable once TooManyDependencies
    public UpdateConferenceDetailCommandHandler(IRepositoryBase<ConferenceDetail> repository, IMapper mapper,
        IConferenceHub conferenceHub, IConferenceDetailRepository conferenceDetailRepository) {
        _repository = repository;
        _mapper = mapper;
        _conferenceHub = conferenceHub;
        _conferenceDetailRepository = conferenceDetailRepository;
    }

    public async Task<ConferenceDetail> Handle(UpdateConferenceDetailCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new UpdateConferenceDetailCommandValidation());

        var conferenceDetail = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (conferenceDetail == null)
            throw new NotFoundException(nameof(ConferenceDetail), request.Id.ToString());

        _mapper.Map(request, conferenceDetail);
        conferenceDetail.ModifiedDate = DateTime.Now;
        if (conferenceDetail is {Status: ConferenceDetailStatus.Published, PublishedDate: null}) {
            conferenceDetail.PublishedDate = DateTime.Now;
            conferenceDetail.PublishedBy = conferenceDetail.ModifiedBy;
        }

        if (request.Status is ConferenceDetailStatus.WaitingEdit or ConferenceDetailStatus.WaitingPublish)
            conferenceDetail.EditorId = request.ModifiedBy;

        conferenceDetail = await _repository.UpdateAsync(conferenceDetail, cancellationToken);

        
        return conferenceDetail;
    }
}