namespace ConferenceModule.Domain.Enums;

public enum ConferenceDetailStatus : byte {
    Created,
    WaitingEdit,
    WaitingPublish,
    Published,
    Deleted
}