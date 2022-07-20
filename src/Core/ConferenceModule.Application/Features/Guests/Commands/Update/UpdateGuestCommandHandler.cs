using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Guests.Commands.Update;

public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Guest> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Guest> _repository;

    public UpdateGuestCommandHandler(IRepositoryBase<Guest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guest> Handle(UpdateGuestCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new UpdateGuestCommandValidation());
        var guest = await _repository.FindByCondition(guest => guest.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if (guest is null) throw new NotFoundException(nameof(Guest), request.Id.ToString());
        _mapper.Map(request, guest);
        guest.ModifiedDate = DateTime.Now;
        return await _repository.UpdateAsync(guest, cancellationToken);
    }
}