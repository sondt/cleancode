namespace ConferenceModule.Domain.Enums;

public enum NewsStatus : byte {
    /// <summary>
    ///     Tạo mới
    /// </summary>
    Create = 0,

    /// <summary>
    ///     Đã xuất bản
    /// </summary>
    Published = 1,

    /// <summary>
    ///     Gửi lên chờ biên tập
    /// </summary>
    EditWait = 2,

    /// <summary>
    ///     Đang biên tập
    /// </summary>
    Editing = 3,

    /// <summary>
    ///     Gửi lên chờ xuất bản
    /// </summary>
    PublishWaiting = 4,

    /// <summary>
    ///     Tin nhận chờ xuất bản
    /// </summary>
    PublishWait = 5,

    /// <summary>
    ///     Tin bị trả lại
    /// </summary>
    Return = 6,

    /// <summary>
    ///     Tin bị gỡ xuống
    /// </summary>
    Unpublished = 7,

    /// <summary>
    ///     Tin đã xóa
    /// </summary>
    Deleted = 8,

    /// <summary>
    ///     Khôi phục bài viết
    /// </summary>
    Restore = 9
}