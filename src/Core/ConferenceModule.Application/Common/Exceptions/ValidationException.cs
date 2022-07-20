using ConferenceModule.Application.Common.Extensions;
using FluentValidation.Results;

namespace ConferenceModule.Application.Common.Exceptions;

public class ValidationException : ApplicationException {
    public ValidationException(ValidationResult validationResult) {
        var errors = validationResult.Errors.Select(validationError => validationError.ErrorMessage).ToList();
        Message = errors.ToJson();
    }

    public override string Message { get; } = null!;
}