using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.Accounts.Queries.Login;

public class LoginQueryValidation : AbstractValidator<LoginQuery> {
    public LoginQueryValidation() {
        RuleFor(x => x.AuthenticationRequest!.Email).NotEmpty().WithMessage(ValidateMessage.NotEmpty).EmailAddress()
            .WithMessage(ValidateMessage.EmailAddress);
        RuleFor(x => x.AuthenticationRequest!.Password).NotEmpty().WithMessage(ValidateMessage.NotEmpty)
            .MinimumLength(6).WithMessage(ValidateMessage.MinimumLength);
    }
}