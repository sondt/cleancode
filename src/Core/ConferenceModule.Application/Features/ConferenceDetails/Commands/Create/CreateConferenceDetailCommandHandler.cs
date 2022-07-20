using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Create;

public class CreateConferenceDetailCommandHandler : IRequestHandler<CreateConferenceDetailCommand, ConferenceDetail> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceDetail> _repository;

    public CreateConferenceDetailCommandHandler(IRepositoryBase<ConferenceDetail> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ConferenceDetail> Handle(CreateConferenceDetailCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new CreateConferenceDetailCommandValidation());

        var conferenceDetail = _mapper.Map<ConferenceDetail>(request);
        conferenceDetail.Id = Guid.NewGuid();
        conferenceDetail.CreatedDate = conferenceDetail.ModifiedDate = DateTime.Now;

        if (conferenceDetail.Status == ConferenceDetailStatus.Published) {
            conferenceDetail.PublishedBy = conferenceDetail.ModifiedBy;
            conferenceDetail.PublishedDate = DateTime.Now;
        }

        conferenceDetail = await _repository.CreateAsync(conferenceDetail, cancellationToken);
        return conferenceDetail;
    }
}