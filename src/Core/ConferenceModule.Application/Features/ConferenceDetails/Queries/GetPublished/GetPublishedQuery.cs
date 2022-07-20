using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished.Models;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished;

public class GetByStatusQuery : IRequest<IReadOnlyCollection<QuestionAnswerDto>> {
    public Guid ConferenceId { get; set; }
}