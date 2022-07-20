using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.Accounts.Commands.Register;

public class RegisterQueryValidation : AbstractValidator<RegisterQuery> {
    public RegisterQueryValidation() {
        RuleFor(x => x.Email).NotEmpty().WithMessage(ValidateMessage.NotEmpty).EmailAddress()
            .WithMessage(ValidateMessage.EmailAddress);
        RuleFor(x => x.Password).NotEmpty().WithMessage(ValidateMessage.NotEmpty).MinimumLength(6)
            .WithMessage(ValidateMessage.MinimumLength);
        RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(ValidateMessage.NotEmpty).Equal(x => x.Password)
            .WithMessage(ValidateMessage.Equal);
        RuleFor(x => x.UserName).NotEmpty().WithMessage(ValidateMessage.NotEmpty);
    }
}