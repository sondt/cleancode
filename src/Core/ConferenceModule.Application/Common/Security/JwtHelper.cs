using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using ConferenceModule.Application.Common.Settings;
using ConferenceModule.Application.Common.Settings.Backend;
using Microsoft.IdentityModel.Tokens;

namespace ConferenceModule.Application.Common.Security;

public static class JwtHelper {
    public static string GenerateToken(TokenModel tokenModel) {
        var keyBytes = new byte[JwtSetting.SecretKey!.Length * sizeof(char)];
        var tokenHandler = new JwtSecurityTokenHandler();
        var descriptor = new SecurityTokenDescriptor {
            Claims = new Dictionary<string, object?> {
                {"id", tokenModel.Id},
                {"username", tokenModel.UserName},
                {"role", Enum.GetName(tokenModel.Role)!}
            },
            Subject = new ClaimsIdentity(new Claim[] {
                new(ClaimTypes.Email, tokenModel.Email!),
                new(ClaimTypes.Role, Enum.GetName(tokenModel.Role)!)
            }),
            Expires = DateTime.UtcNow.AddMinutes(JwtSetting.ExpireTime),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256),
            Issuer = JwtSetting.Issuer,
            NotBefore = DateTime.UtcNow,
            IssuedAt = DateTime.UtcNow
        };

        var token = tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(token);
    }


    [Obsolete("Obsolete")]
    public static string GenerateRefreshToken() {
        var byteArray = new byte[64];
        using var cryptoProvider = new RNGCryptoServiceProvider();
        cryptoProvider.GetBytes(byteArray);
        return Convert.ToBase64String(byteArray);
    }
}