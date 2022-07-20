using ConferenceModule.Application.Common.Models;
using HttpMethod = ConferenceModule.Application.Common.Models.HttpMethod;

namespace ConferenceModule.Application.Common.Services;

public class RequestModel {
    public RequestModel(string url, HttpMethod method) {
        Url = url;
        Method = method;
    }

    public string Url { get; set; } = null!;
    public HttpMethod Method { get; set; }
    public string? Body { get; set; }
    public AcceptType AcceptType { get; set; } = AcceptType.Json;
    public string? BearerToken { get; set; }
    public CancellationToken CancellationToken { get; set; } = CancellationToken.None;
    public Dictionary<string, object>? Parameters { get; set; }
    public Dictionary<string, object>? Headers { get; set; }
}