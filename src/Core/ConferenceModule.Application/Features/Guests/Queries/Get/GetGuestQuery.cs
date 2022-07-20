using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Guests.Queries.Get;

public class GetGuestQuery : IRequest<Guest?> {
    public Guid Id { get; set; }
}