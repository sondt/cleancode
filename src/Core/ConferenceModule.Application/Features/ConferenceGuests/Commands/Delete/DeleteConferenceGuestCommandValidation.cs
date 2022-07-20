using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.ConferenceGuests.Commands.Delete;

public class DeleteConferenceGuestCommandValidation : AbstractValidator<DeleteConferenceGuestCommand> {
    public DeleteConferenceGuestCommandValidation() {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidateMessage.NotEmpty);
    }
}