using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.Guests.Commands.Delete;

public class DeleteGuestCommandValidation : AbstractValidator<DeleteGuestCommand> {
    public DeleteGuestCommandValidation() {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidateMessage.NotEmpty);
    }
}