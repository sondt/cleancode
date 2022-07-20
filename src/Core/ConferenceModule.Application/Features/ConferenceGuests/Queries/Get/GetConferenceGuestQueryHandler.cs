using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceGuests.Queries.Get;

public class GetConferenceGuestQueryHandler : IRequestHandler<GetConferenceGuestQuery, ConferenceGuest?> {
    private readonly IRepositoryBase<ConferenceGuest> _repository;

    public GetConferenceGuestQueryHandler(IRepositoryBase<ConferenceGuest> repository) {
        _repository = repository;
    }

    public async Task<ConferenceGuest?> Handle(GetConferenceGuestQuery request, CancellationToken cancellationToken) {
        return await _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}