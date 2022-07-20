namespace ConferenceModule.Application.Contracts.Conferences;

public interface IConferenceHub {
    Task PushConferenceToAllClientsAsync(ConferenceResponse response);
}