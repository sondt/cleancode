using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Commands.Create;

public class CreateGuestCommandHandler : IRequestHandler<CreateGuestCommand, Guest> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Guest> _repository;

    public CreateGuestCommandHandler(IRepositoryBase<Guest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guest> Handle(CreateGuestCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new CreateGuestCommandValidation());

        var guest = _mapper.Map<Guest>(request);
        guest.Id = Guid.NewGuid();
        guest.ModifiedBy = guest.CreatedBy;
        guest.CreatedDate = guest.ModifiedDate = DateTime.Now;

        return await _repository.CreateAsync(guest, cancellationToken);
    }
}