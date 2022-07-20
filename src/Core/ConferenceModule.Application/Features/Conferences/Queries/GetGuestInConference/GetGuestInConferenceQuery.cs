using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;

public class GetGuestInConferenceQuery : IRequest<IReadOnlyList<GuestInConferenceDto>?> {
    public Guid ConferenceId { get; set; }
    public long ArticleId { get; set; }
}