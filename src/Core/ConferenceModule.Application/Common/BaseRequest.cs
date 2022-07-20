namespace ConferenceModule.Application.Common;

public class BaseRequest {
    public BaseRequest(Guid? id, CancellationToken cancellationToken) {
        Id = id;
        CancellationToken = cancellationToken;
    }

    public Guid? Id { get; set; }
    public CancellationToken CancellationToken { get; set; }
}