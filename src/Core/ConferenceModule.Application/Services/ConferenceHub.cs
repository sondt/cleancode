using ConferenceModule.Application.Common.Settings;
using ConferenceModule.Application.Contracts.Conferences;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConferenceModule.Application.Services;

public class ConferenceHub : IConferenceHub {
    private readonly HubConnection? _connection;

    public ConferenceHub() {
        if (_connection != null) return;
        _connection = new HubConnectionBuilder().WithUrl(ApplicationSetting.ConferenceHub).Build();
        _connection.StartAsync();
    }

    public async Task PushConferenceToAllClientsAsync(ConferenceResponse response) {
        response.Questioner!.Email = "";
        response.Questioner!.Id = Guid.Empty;
        response.Respondent!.Id = Guid.Empty;
        await _connection!.SendAsync("SendMessage", response);
    }
}