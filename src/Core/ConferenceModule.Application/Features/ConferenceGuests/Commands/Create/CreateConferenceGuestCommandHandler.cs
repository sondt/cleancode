using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.ConferenceGuests;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Create;

public class CreateConferenceGuestCommandHandler : IRequestHandler<CreateConferenceGuestCommand, ConferenceGuest> {
    private readonly IConferenceGuestRepository _conferenceGuestRepository;
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceGuest> _repository;

    public CreateConferenceGuestCommandHandler(IRepositoryBase<ConferenceGuest> repository, IMapper mapper,
        IConferenceGuestRepository conferenceGuestRepository) {
        _repository = repository;
        _mapper = mapper;
        _conferenceGuestRepository = conferenceGuestRepository;
    }

    public async Task<ConferenceGuest> Handle(CreateConferenceGuestCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new CreateConferenceGuestCommandValidation());

        var existing =
            await _conferenceGuestRepository.GetByConferenceIdAndGuestId(request.ConferenceId, request.GuestId);
        if (existing != null)
            throw new BadRequestException(ConferenceMessage.ExistGuestInConference);

        var conferenceGuest = _mapper.Map<ConferenceGuest>(request);
        conferenceGuest.Id = Guid.NewGuid();
        return await _repository.CreateAsync(conferenceGuest, cancellationToken);
    }
}