using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Delete;

public class DeleteConferenceGuestCommandHandler : IRequestHandler<DeleteConferenceGuestCommand, int> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceGuest> _repository;

    public DeleteConferenceGuestCommandHandler(IRepositoryBase<ConferenceGuest> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(DeleteConferenceGuestCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new DeleteConferenceGuestCommandValidation());

        var guest = await _repository.FindByCondition(guest => guest.Id.Equals(request.Id))
            .FirstOrDefaultAsync(cancellationToken);
        if (guest is null) throw new NotFoundException(nameof(Guest), request.Id.ToString());

        return await _repository.DeleteAsync(guest, cancellationToken);
    }
}