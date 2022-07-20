using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.Guests.Commands.Update;

public class UpdateGuestCommandValidation : AbstractValidator<UpdateGuestCommand> {
    public UpdateGuestCommandValidation() {
        RuleFor(x => x.Id).NotEmpty().WithMessage(ValidateMessage.NotEmpty);
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidateMessage.NotEmpty);
    }
}