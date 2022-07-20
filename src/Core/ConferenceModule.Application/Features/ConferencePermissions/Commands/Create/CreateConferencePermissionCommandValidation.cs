using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.ConferencePermissions.Commands.Create;

public class CreateConferencePermissionCommandValidation : AbstractValidator<CreateConferencePermissionCommand> {
    public CreateConferencePermissionCommandValidation() {
        RuleFor(x => x.ConferenceId).NotNull().WithMessage(ValidateMessage.NotNull);
        RuleFor(x => x.Role).NotNull().WithMessage(ValidateMessage.NotNull).NotEmpty()
            .WithMessage(ValidateMessage.NotEmpty);
        RuleFor(x => x.UserId).NotNull().WithMessage(ValidateMessage.NotNull).GreaterThan(0)
            .WithMessage(ValidateMessage.InvalidUser);
    }
}