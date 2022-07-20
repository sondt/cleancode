using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Update;

public class UpdateConferenceGuestCommandHandler : IRequestHandler<UpdateConferenceGuestCommand, ConferenceGuest> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceGuest> _repository;

    public UpdateConferenceGuestCommandHandler(IRepositoryBase<ConferenceGuest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ConferenceGuest> Handle(UpdateConferenceGuestCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new UpdateConferenceGuestCommandValidation());
        var guest = await _repository.FindByCondition(guest => guest.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if (guest is null) throw new NotFoundException(nameof(Guest), request.Id.ToString());
        _mapper.Map(request, guest);
        return await _repository.UpdateAsync(guest, cancellationToken);
    }
}