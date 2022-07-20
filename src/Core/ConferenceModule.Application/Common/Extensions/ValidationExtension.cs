using ConferenceModule.Application.Common.Services;
using FluentValidation;
using ValidationException = ConferenceModule.Application.Common.Exceptions.ValidationException;

namespace ConferenceModule.Application.Common.Extensions;

public static class ValidationExtension {
    public static async Task Validate<T, TU>(this IGuardClause guardClause, T request, TU validator)
        where T : new() where TU : AbstractValidator<T> {
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any()) throw new ValidationException(validationResult);
    }
}