using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;

public class
    CreateConferenceDetailWithoutAccountCommandValidation : AbstractValidator<
        CreateConferenceDetailWithoutAccountCommand> {
    public CreateConferenceDetailWithoutAccountCommandValidation() {
        RuleFor(x => x.ConferenceId).NotNull().WithMessage(ValidateMessage.NotNull);
        RuleFor(x => x.Question).NotNull().WithMessage(ValidateMessage.NotNull).NotEmpty()
            .WithMessage(ValidateMessage.NotEmpty);
        RuleFor(x => x.QuestionerName).NotNull().WithMessage(ValidateMessage.NotNull);
        RuleFor(x => x.QuestionerEmail).NotNull().WithMessage(ValidateMessage.NotNull).EmailAddress()
            .WithMessage(ValidateMessage.EmailAddress);
    }
}