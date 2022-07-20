using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceModule.Domain.BaseModels;

public abstract class BaseEntity {
    private readonly List<BaseEvent> _events = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _events.AsReadOnly();

    public void AddEvent(BaseEvent baseEvent) {
        _events.Add(baseEvent);
    }

    public void RemoveEvent(BaseEvent baseEvent) {
        _events.Remove(baseEvent);
    }

    public void ClearEvents() {
        _events.Clear();
    }
}