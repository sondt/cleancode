using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.Get;

public class GetConferenceDetailQuery : IRequest<QuestionAnswerDto?> {
    public Guid Id { get; set; }
    public int UserId { get; set; }
}