using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Update;

public class UpdateConferenceCommand : IRequest<Conference> {
    public UpdateConferenceModel Conference { get; init; } = null!;
}