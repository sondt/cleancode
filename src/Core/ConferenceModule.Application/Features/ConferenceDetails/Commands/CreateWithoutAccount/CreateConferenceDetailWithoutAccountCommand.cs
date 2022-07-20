using System.ComponentModel.DataAnnotations;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;

public class CreateConferenceDetailWithoutAccountCommand : IRequest<ConferenceDetail> {
    public Guid ConferenceId { get; set; }
    public Guid? GuestId { get; set; }
    public string QuestionerName { get; set; } = null!;

    [EmailAddress]
    public string QuestionerEmail { get; set; } = null!;

    public string? Question { get; set; }
    public string? Answer { get; set; }
    public int? ModifiedBy { get; set; }
    public ConferenceDetailStatus Status { get; set; }
}