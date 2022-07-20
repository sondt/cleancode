using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;

namespace ConferenceModule.Application.Contracts.Conferences;

public interface IConferenceDetailRepository {
    Task<QuestionAnswerDto?> GetQuestionAnswerAsync(Guid conferenceDetailId, CancellationToken cancellationToken);
}