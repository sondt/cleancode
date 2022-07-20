namespace ConferenceModule.Application.Common.Services;

public interface IHttpService {
    Task<string> GetStringAsync(RequestModel request);
    Task<HttpResponseMessage> GetAsync(RequestModel request);
   Task ClearCacheAsync(RequestModel request);
    // Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer");
    // Task<HttpResponseMessage> PostAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
    // Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
    // Task<HttpResponseMessage> PutAsync<T>(string uri, T item, string authorizationToken = null, string authorizationMethod = "Bearer");
    // Task<HttpResponseMessage> PutAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
}