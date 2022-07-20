using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Create;

public class CreateConferenceDetailCommandValidation : AbstractValidator<CreateConferenceDetailCommand> {
    public CreateConferenceDetailCommandValidation() {
        RuleFor(x => x.ConferenceId).NotNull().WithMessage(ValidateMessage.NotNull);
        RuleFor(x => x.Question).NotNull().WithMessage(ValidateMessage.NotNull).NotEmpty()
            .WithMessage(ValidateMessage.NotEmpty);
        RuleFor(x => x.AccountId).NotNull().WithMessage(ValidateMessage.NotNull);
    }
}