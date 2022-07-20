namespace ConferenceModule.Domain.Models;

public class PagedResult<T> : PagedResultBase where T : class {
    public PagedResult() {
        Results = new List<T>();
    }

    public IReadOnlyCollection<T> Results { get; set; }
}