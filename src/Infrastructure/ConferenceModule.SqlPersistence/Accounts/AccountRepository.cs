using ConferenceModule.Application.Contracts.Accounts;
using ConferenceModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence.Accounts;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository {
    public AccountRepository(MediaContext mediaContext) : base(mediaContext) {
    }

    public async Task<Account?> Login(string? email, string password, CancellationToken cancellationToken) {
        return await FindByCondition(x => x.Email == email && x.Password == password)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Account> Create(Account account, CancellationToken cancellationToken) {
        return await CreateAsync(account, cancellationToken);
    }
}