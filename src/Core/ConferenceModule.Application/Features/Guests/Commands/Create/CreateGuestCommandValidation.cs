using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.Guests.Commands.Create;

public class CreateGuestCommandValidation : AbstractValidator<CreateGuestCommand> {
    public CreateGuestCommandValidation() {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidateMessage.NotEmpty);

        RuleFor(x => x.CreatedBy).NotNull().WithMessage(ValidateMessage.NotNull).GreaterThan(0)
            .WithMessage(ValidateMessage.InvalidUser);
    }
}