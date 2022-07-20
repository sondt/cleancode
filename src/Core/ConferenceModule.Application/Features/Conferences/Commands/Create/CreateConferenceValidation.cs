using ConferenceModule.Application.Common.Message;
using FluentValidation;
using FluentValidation.Results;

namespace ConferenceModule.Application.Features.Conferences.Commands.Create;

public class CreateConferenceValidation : AbstractValidator<CreateConferenceModel> {
    public CreateConferenceValidation() {
        RuleFor(model => model.NewsId).GreaterThan(0).WithMessage(ValidateMessage.GreaterThan);
        RuleFor(o => o.EndTime).GreaterThan(o => o.StartTime).WithMessage(ValidateMessage.GreaterThan);
    }

    protected override bool PreValidate(ValidationContext<CreateConferenceModel> context, ValidationResult result) {
        if (context.InstanceToValidate == null) throw new ArgumentNullException(nameof(CreateConferenceModel));
        return base.PreValidate(context, result);
    }
}