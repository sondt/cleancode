using ConferenceModule.Application.Common;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Contracts.Accounts;

public interface IAccountRepository : IRepositoryBase<Account> {
    Task<Account?> Login(string? email, string password, CancellationToken cancellationToken);
    Task<Account> Create(Account account, CancellationToken cancellationToken);
}