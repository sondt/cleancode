using System.Diagnostics.CodeAnalysis;
using ConferenceModule.Domain.BaseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
[SuppressMessage("ReSharper", "TooManyDeclarations")]
public static class MediatorExtensions {
    public static async Task DispatchEvents(this IMediator mediator, DbContext context) {
        var entities = context.ChangeTracker.Entries<BaseEntity>().Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var baseEvents = entities.SelectMany(e => e.DomainEvents).ToList();

        entities.ToList().ForEach(e => e.ClearEvents());

        foreach (var baseEvent in baseEvents) await mediator.Publish(baseEvent);
    }
}