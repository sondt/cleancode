using System.ComponentModel;

namespace ConferenceModule.Domain.Enums;

public enum Status : byte {
    [Description("Tất cả")]
    All,

    [Description("Hoạt động")]
    Active,

    [Description("Không hoạt động")]
    InActive
}