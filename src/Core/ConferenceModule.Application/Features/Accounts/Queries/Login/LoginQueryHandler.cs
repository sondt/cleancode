using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Application.Common.Security;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Accounts;
using ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.Accounts.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse> {
    private readonly IAccountRepository _accountRepository;

    public LoginQueryHandler(IAccountRepository accountRepository) {
        _accountRepository = accountRepository;
    }

    public async Task<AuthenticationResponse> Handle(LoginQuery request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new LoginQueryValidation());
        var encryptPassword = request.AuthenticationRequest!.Password!.EncryptPassword();
        var account =
            await _accountRepository.Login(request.AuthenticationRequest.Email, encryptPassword, cancellationToken);

        if (account == null) throw new BadRequestException(AccountMessage.InvalidLogin);

        switch (account) {
            case {Status: AccountStatus.Locked}:
                throw new BadRequestException(AccountMessage.AccountLocked);
            case {Status: AccountStatus.WaitingVerify}:
            case {Status: AccountStatus.All}:
                throw new BadRequestException(AccountMessage.WaitingVerify);
            default: {
                var tokenString = JwtHelper.GenerateToken(new TokenModel {
                    Email = account.Email, Id = account.Id.ToString(), UserName = account.UserName, Role = Role.User
                });

                return new AuthenticationResponse {
                    Success = true, Token = tokenString
                };
            }
        }
    }
}