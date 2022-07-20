using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence;

public class MediaContext : DbContext {
    private readonly IMediator _mediator;

    public MediaContext(DbContextOptions<MediaContext> options, IMediator mediator) : base(options) {
        _mediator = mediator;
    }

    public virtual DbSet<Account> Accounts { get; set; } = null!;
    public virtual DbSet<Conference> Conferences { get; set; } = null!;
    public virtual DbSet<ConferenceGuest> ConferenceGuests { get; set; } = null!;
    public virtual DbSet<ConferenceDetail> ConferenceDetails { get; set; } = null!;
    public virtual DbSet<Guest> Guests { get; set; } = null!;
    public virtual DbSet<Article> Articles { get; set; } = null!;
    public virtual DbSet<ConferencePermission> ConferencePermissions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder
            //.LogTo(Log.Information, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            //.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).EnableSensitiveDataLogging();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new()) {
        await _mediator.DispatchEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}