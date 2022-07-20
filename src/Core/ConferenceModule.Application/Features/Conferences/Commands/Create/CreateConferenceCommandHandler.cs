using AutoMapper;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Create;

public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, Conference> {
    private readonly IConferenceRepository _conferenceRepository;
    private readonly IMapper _mapper;

    public CreateConferenceCommandHandler(IConferenceRepository conferenceRepository, IMapper mapper) {
        _conferenceRepository = conferenceRepository;
        _mapper = mapper;
    }

    public async Task<Conference> Handle(CreateConferenceCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request.CreateConferenceModel, new CreateConferenceValidation());

        var onlineExchange = _mapper.Map<Conference>(request.CreateConferenceModel);
        onlineExchange.Id = Guid.NewGuid();

        return await _conferenceRepository.CreateAsync(onlineExchange, cancellationToken);
    }
}