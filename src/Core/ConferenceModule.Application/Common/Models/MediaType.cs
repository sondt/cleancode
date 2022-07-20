namespace ConferenceModule.Application.Common.Models;

public class MediaType {
    public static string GetMediaType(AcceptType type) {
        return type switch {
            AcceptType.Binary => Binary,
            AcceptType.Bmp => Bmp,
            AcceptType.Gif => Gif,
            AcceptType.Html => Html,
            AcceptType.Jpeg => Jpeg,
            AcceptType.Json => Json,
            AcceptType.Png => Png,
            AcceptType.Svg => Svg,
            AcceptType.Text => Text,
            AcceptType.Xml => Xml,
            AcceptType.Ttf => Ttf,
            AcceptType.Woff => Woff,
            AcceptType.Woff2 => Woff2,
            AcceptType.FormUrlEncoded => FormUrlEncoded,
            AcceptType.MultipartFormData => MultipartFormData,
            AcceptType.JavaScript => JavaScript,
            _ => Json
        };
    }

    private static string Json => "application/json";
    private static string FormUrlEncoded => "application/x-www-form-urlencoded";
    private static string MultipartFormData => "multipart/form-data";
    private static string Text => "text/plain";
    private static string Xml => "application/xml";
    private static string Binary => "application/octet-stream";
    private static string Html => "text/html";
    private static string Jpeg => "image/jpeg";
    private static string Png => "image/png";
    private static string Gif => "image/gif";
    private static string Bmp => "image/bmp";
    private static string Svg => "image/svg+xml";
    private static string Woff => "application/font-woff";
    private static string Woff2 => "application/font-woff2";
    private static string Ttf => "application/font-ttf";
    private static string JavaScript => "application/javascript";
}