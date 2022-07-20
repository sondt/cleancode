namespace ConferenceModule.Application.Common.Settings.Backend;

public class JwtSetting {
    public static int ExpireTime { get; set; }
    public static string SecretKey { get; set; } = null!;
    public static string Issuer { get; set; } = null!;
}