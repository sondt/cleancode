using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Delete;

public class DeleteConferenceCommand : IRequest<int> {
    public Guid Id { get; set; }
}