using ConferenceModule.Application.Common.Message;
using FluentValidation;
using FluentValidation.Results;

namespace ConferenceModule.Application.Features.Conferences.Commands.Update;

public class UpdateConferenceValidation : AbstractValidator<UpdateConferenceModel> {
    public UpdateConferenceValidation() {
        RuleFor(model => model.NewsId).GreaterThan(0).WithMessage(ValidateMessage.GreaterThan);

        RuleFor(o => o.EndTime).GreaterThan(o => o.StartTime).WithMessage(ValidateMessage.GreaterThan);
    }

    protected override bool PreValidate(ValidationContext<UpdateConferenceModel> context, ValidationResult result) {
        if (context.InstanceToValidate == null) throw new ArgumentNullException(nameof(UpdateConferenceModel));
        return base.PreValidate(context, result);
    }
}