using ConferenceModule.Application.Contracts.ConferenceGuests;
using ConferenceModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence;

public class ConferenceGuestRepository : RepositoryBase<ConferenceGuest>, IConferenceGuestRepository {
    public ConferenceGuestRepository(MediaContext mediaContext) : base(mediaContext) {
    }

    public async Task<ConferenceGuest?> GetByConferenceIdAndGuestId(Guid conferenceId, Guid guestId) {
        return await FindByCondition(conferenceGuest =>
                conferenceGuest.GuestId.Equals(guestId) && conferenceGuest.ConferenceId.Equals(conferenceId))
            .FirstOrDefaultAsync();
    }
}