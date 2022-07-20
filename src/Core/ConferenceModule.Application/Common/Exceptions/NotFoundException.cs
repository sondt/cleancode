using System.Diagnostics.CodeAnalysis;
using ConferenceModule.Application.Common.Extensions;

namespace ConferenceModule.Application.Common.Exceptions;

[SuppressMessage("ReSharper", "ComplexConditionExpression")]
public class NotFoundException : ApplicationException {
    public NotFoundException(object? objectName, string? objectId) {
        var messages = new List<string>();
        if (objectId == null && objectName == null) messages.Add("Không tìm thấy tài nguyên bạn yêu cầu");
        if (objectId != null && objectName == null) messages.Add("Không tìm thấy đối tượng có Id là: {objectId}");
        if (objectId == null && objectName != null) messages.Add($"Không tìm thấy đối tượng {objectName}");
        if (objectId != null && objectName != null)
            messages.Add($"Không tìm thấy đối tượng {objectName} có Id là: {objectId}");
        Message = messages.ToJson();
    }

    public override string Message { get; } = null!;
}