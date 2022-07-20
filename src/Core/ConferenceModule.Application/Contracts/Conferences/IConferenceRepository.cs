using ConferenceModule.Application.Common;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Contracts.Conferences;

public interface IConferenceRepository {
    Task<Conference?> GetAsync(BaseRequest baseRequest);
    Task<Conference> CreateAsync(Conference conference, CancellationToken cancellationToken);
    Task<Conference> UpdateAsync(Conference conference, CancellationToken cancellationToken);
    Task<int> DeleteAsync(Conference conference, CancellationToken cancellationToken);
}