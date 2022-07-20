using System.Net.Http.Headers;
using ConferenceModule.Application.Common.Models;
using ConferenceModule.Application.Common.Services;

namespace ConferenceModule.Application.Services;

public class HttpService : IHttpService {
    private static HttpClient? _httpClient;

    public HttpService(IHttpClientFactory httpClientFactory) {
        _httpClient ??= httpClientFactory.CreateClient("HttpClientApi");
    }

    public Task<string> GetStringAsync(RequestModel request) {
        return GetAsync(request).Result.Content.ReadAsStringAsync();
    }

    public Task<HttpResponseMessage> GetAsync(RequestModel request) {
        _httpClient!.DefaultRequestHeaders.Clear();
        _httpClient!.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(MediaType.GetMediaType(request.AcceptType)));
        if (request.Headers != null) {
            foreach (var keyValuePair in request.Headers) {
                _httpClient.DefaultRequestHeaders.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
        }
        return _httpClient.GetAsync(request.Url, cancellationToken:request.CancellationToken);
    }


    public Task ClearCacheAsync(RequestModel request) {
        request.Headers = new Dictionary<string, object> {{"clear-cache", "true"}};
        return GetAsync(request);
    }
}