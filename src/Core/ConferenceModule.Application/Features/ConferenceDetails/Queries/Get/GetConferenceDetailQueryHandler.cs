using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.Get;

public class GetConferenceDetailQueryHandler : IRequestHandler<GetConferenceDetailQuery, QuestionAnswerDto?> {
    private readonly IConferenceDetailRepository _repository;

    public GetConferenceDetailQueryHandler(IConferenceDetailRepository repository) {
        _repository = repository;
    }

    public async Task<QuestionAnswerDto?>
        Handle(GetConferenceDetailQuery request, CancellationToken cancellationToken) {
        var response = await _repository.GetQuestionAnswerAsync(request.Id, cancellationToken);
        if (response == null) return default;
        if (response.Status == ConferenceDetailStatus.WaitingEdit && request.UserId != response.EditorId)
            throw new BadRequestException(ConferenceMessage.AnotherUserEditing);
        return response;
    }
}