using ConferenceModule.Application.Common;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence.Conferences;

public class ConferenceRepository : RepositoryBase<Conference>, IConferenceRepository {
    public ConferenceRepository(MediaContext mediaContext) : base(mediaContext) {
    }

    public async Task<Conference?> GetAsync(BaseRequest baseRequest) {
        return await FindByCondition(exchange => exchange.Id.Equals(baseRequest.Id))
            .FirstOrDefaultAsync(baseRequest.CancellationToken);
    }

    public new async Task<Conference> CreateAsync(Conference conference, CancellationToken cancellationToken) {
        return await base.CreateAsync(conference, cancellationToken);
    }

    public new async Task<Conference> UpdateAsync(Conference conference, CancellationToken cancellationToken) {
        return await base.UpdateAsync(conference, cancellationToken);
    }

    public new async Task<int> DeleteAsync(Conference conference, CancellationToken cancellationToken) {
        return await base.DeleteAsync(conference, cancellationToken);
    }
}