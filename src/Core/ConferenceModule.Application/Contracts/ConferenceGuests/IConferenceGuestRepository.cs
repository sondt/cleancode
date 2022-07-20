using ConferenceModule.Domain;

namespace ConferenceModule.Application.Contracts.ConferenceGuests;

public interface IConferenceGuestRepository {
    Task<ConferenceGuest?> GetByConferenceIdAndGuestId(Guid conferenceId, Guid guestId);
}