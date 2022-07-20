using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.RegularExpressions;
using ConferenceModule.Application.Common.Security;

namespace ConferenceModule.Application.Common.Extensions;

public static class StringExtension {
    public static string ToJson(this object? input, bool isUnsafeRelaxedJson = false) {
        return input is null
            ? string.Empty
            : JsonSerializer.Serialize(input, new JsonSerializerOptions {
                WriteIndented = false, PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Encoder = isUnsafeRelaxedJson ? JavaScriptEncoder.UnsafeRelaxedJsonEscaping : JavaScriptEncoder.Default
            });
    }

    public static string RemoveScripts(this string str) {
        return Regex.Replace(str, @"<script[^>]*>[\s\S]*?</script>", "", RegexOptions.IgnoreCase);
    }

    public static string RemoveAllHtmlTags(this string str) {
        return Regex.Replace(str, "<.*?>", string.Empty);
    }

    public static string ToBase64(this string str) {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
    }

    public static string FromBase64(this string str) {
        return Encoding.UTF8.GetString(Convert.FromBase64String(str));
    }

    public static string EncryptPassword(this string? password) {
        return SecurityHelper.EncryptSha1(password);
    }
}