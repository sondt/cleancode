using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.Get;

public class GetConferenceQuery : IRequest<GetConferenceModel?> {
    public Guid? Id { get; set; }
}