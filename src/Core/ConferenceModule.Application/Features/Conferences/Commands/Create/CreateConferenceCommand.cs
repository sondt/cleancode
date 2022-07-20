using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Create;

public class CreateConferenceCommand : IRequest<Conference> {
    public CreateConferenceModel CreateConferenceModel { get; init; } = null!;
}