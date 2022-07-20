using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Queries.Get;

public class GetGuestQueryHandler : IRequestHandler<GetGuestQuery, Guest?> {
    private readonly IRepositoryBase<Guest> _repository;

    public GetGuestQueryHandler(IRepositoryBase<Guest> repository) {
        _repository = repository;
    }

    public async Task<Guest?> Handle(GetGuestQuery request, CancellationToken cancellationToken) {
        return await _repository.GetByIdAsync(request.Id, cancellationToken);
    }
}