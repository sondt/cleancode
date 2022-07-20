using ConferenceModule.Application.Common.Extensions;

namespace ConferenceModule.Application.Common.Exceptions;

public class BadRequestException : ApplicationException {
    public BadRequestException(string? message) {
        var messages = new List<string> {message!};
        Message = messages.ToJson();
    }

    public override string Message { get; } = null!;
}