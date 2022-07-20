using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Guests.Commands.Delete;

public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, int> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<Guest> _repository;

    public DeleteGuestCommandHandler(IRepositoryBase<Guest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(DeleteGuestCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new DeleteGuestCommandValidation());
        var guest = await _repository.FindByCondition(guest => guest.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if (guest is null) throw new NotFoundException(nameof(Guest), request.Id.ToString());
        return await _repository.DeleteAsync(guest, cancellationToken);
    }
}