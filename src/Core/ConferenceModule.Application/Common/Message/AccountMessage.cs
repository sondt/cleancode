using System.Diagnostics.CodeAnalysis;

namespace ConferenceModule.Application.Common.Message;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class AccountMessage {
    public static string? InvalidLogin { get; set; }
    public static string? InvalidEmail { get; set; }
    public static string? ExistsEmail { get; set; }
    public static string? AccountLocked { get; set; }
    public static string? WaitingVerify { get; set; }
}