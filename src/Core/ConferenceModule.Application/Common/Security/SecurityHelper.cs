using System.Security.Cryptography;
using System.Text;

namespace ConferenceModule.Application.Common.Security;

public class SecurityHelper {
    public static string EncryptSha1(string? input) {
        var sha1 = SHA1.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input!);
        var hash = sha1.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var t in hash) sb.Append(t.ToString("X2"));

        return sb.ToString();
    }

    public static string EncryptMd5(string input) {
        var md5 = MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hash = md5.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var t in hash) sb.Append(t.ToString("X2"));

        return sb.ToString();
    }
}