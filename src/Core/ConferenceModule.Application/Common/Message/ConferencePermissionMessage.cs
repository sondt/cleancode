using System.Diagnostics.CodeAnalysis;

namespace ConferenceModule.Application.Common.Message;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class ConferencePermissionMessage {
    public static string? Existing { get; set; }
}