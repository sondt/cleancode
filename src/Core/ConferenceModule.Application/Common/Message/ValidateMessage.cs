namespace ConferenceModule.Application.Common.Message;

public static class ValidateMessage {
    public const string MustIsLongType = "'{PropertyName}' kiểu dữ liệu phải là kiểu 'long'";
    public const string Required = "{PropertyName}: được yêu cầu";
    public const string NotEmpty = "{PropertyName}: không được để trống";
    public const string MobileInValid = "{PropertyName}: số điện thoại không hợp lệ";
    public const string EmailAddress = "{PropertyName}: email không hợp lệ";
    public const string Maxlength = "{PropertyName}: độ dài tối đa là {MaxLength}";
    public const string GreaterThan = "{PropertyName}: phải lớn hơn {PropertyValue}";
    public const string LessThan = "{PropertyName}: phải nhỏ hơn {PropertyValue}.";
    public const string GreaterThanOrEqual = "{PropertyName}: phải lớn hơn hoặc bằng {PropertyValue}.";
    public const string LessThanOrEqual = "{PropertyName}: phải nhỏ hơn hoặc bằng {PropertyValue}.";
    public const string MinimumLength = "{PropertyName}: phải có ít nhất {MinLength} ký tự";
    public const string DirectoryNotEmpty = "Directory not empty, you can't delete it.";
    public const string IsNotValid = "{PropertyName}: không hợp lệ";
    public const string AtLatestMinItems = "Cần có ít nhất {MinItems} phần tử";
    public const string Duplicate = "Trùng lặp";
    public const string NotNull = "{PropertyName}: Không chấp nhận giá trị null";
    public const string Equal = "{PropertyName}: phải bằng {PropertyValue}";
    public const string InvalidUser = "Người dùng không hợp lệ";
}