using ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;

namespace ConferenceModule.Application.Contracts.Accounts;

public interface IAuthentication {
    Task<AuthenticationResponse> GenerateTokenAsync(AuthenticationRequest authModel);
    Task<AuthenticationResponse> RefreshTokenAsync(string ipAddress, Guid accountId, string email);
    Task<bool> IsTokenValid(string accessToken, string ipAddress);
}