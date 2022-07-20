using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain.Enums;
using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus;

public class GetByStatusQuery : FindBaseModel, IRequest<PagedResult<QuestionAnswerDto>> {
    public Guid ConferenceId { get; set; }
    public ConferenceDetailStatus Status { get; set; }

    public int UserId { get; set; }
}