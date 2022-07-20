using AutoMapper;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Accounts;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;

namespace ConferenceModule.Application.Features.Accounts.Commands.Register;

public class RegisterQueryHandler : IRequestHandler<RegisterQuery, Account> {
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public RegisterQueryHandler(IAccountRepository accountRepository, IMapper mapper) {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<Account> Handle(RegisterQuery request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new RegisterQueryValidation());
        var account = _mapper.Map<Account>(request);
        account.Password = account.Password.EncryptPassword();
        account.Status = AccountStatus.Active;
        account = await _accountRepository.Create(account, cancellationToken);
        account.Password = string.Empty;
        return account;
    }
}