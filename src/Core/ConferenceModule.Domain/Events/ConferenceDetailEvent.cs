using ConferenceModule.Domain.BaseModels;

namespace ConferenceModule.Domain.Events;

public class ConferenceDetailEvent : BaseEvent {
    public ConferenceDetailEvent(ConferenceDetail conferenceDetail) {
        ConferenceDetail = conferenceDetail;
    }

    public ConferenceDetail ConferenceDetail { get; }
}