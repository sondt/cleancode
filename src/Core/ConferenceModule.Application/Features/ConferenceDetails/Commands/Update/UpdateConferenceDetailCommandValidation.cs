using ConferenceModule.Application.Common.Message;
using FluentValidation;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.Update;

public class UpdateConferenceDetailCommandValidation : AbstractValidator<UpdateConferenceDetailCommand> {
    public UpdateConferenceDetailCommandValidation() {
        RuleFor(x => x.Question).NotNull().WithMessage(ValidateMessage.NotNull).NotEmpty()
            .WithMessage(ValidateMessage.NotEmpty);
        RuleFor(x => x.ModifiedBy).NotNull().WithMessage(ValidateMessage.NotNull).GreaterThan(0)
            .WithMessage(ValidateMessage.InvalidUser);
    }
}