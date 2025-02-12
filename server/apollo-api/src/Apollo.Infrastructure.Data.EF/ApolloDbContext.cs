using Apollo.Core.Domain.Identity.Entities;
using Apollo.Libraries.Core.Domain.Entities;
using Apollo.Libraries.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Infrastructure.Data.EF;

public class ApolloDbContext : DbContext, IUnitOfWork
{
	private readonly MediatR.IMediator? _mediator;

	public ApolloDbContext(DbContextOptions<ApolloDbContext> options) : base(options) { }

	public ApolloDbContext(DbContextOptions<ApolloDbContext> options, MediatR.IMediator mediator) : base(options)
		=> _mediator = mediator;

	public DbSet<UserProfile> UserProfiles { get; init; } = default!;

	public async Task CommitAsync(CancellationToken ct = default)
	{
		// dispatch domain events
		await this.DispatchDomainEvents(ct);

		// save changes
		await this.SaveChangesAsync(ct);

		// dispatch integration events
		await this.DispatchIntegrationEvents(ct);
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);

		configurationBuilder.Properties<UserProfileId>()
							.HaveConversion<EntityFxEntityKeyConverter<UserProfileId>>()
							.HaveMaxLength(64);

		configurationBuilder.Properties<string>().AreUnicode();
		configurationBuilder.Properties<decimal>().HavePrecision(24, 8);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApolloDbContext).Assembly);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		// current timestamp
		var timestamp = DateTimeOffset.UtcNow;
		
		// update created and last modified date of every entity being saved
		var entries   = this.ChangeTracker.Entries<IEntity>();

		foreach (var entry in entries)
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property<DateTimeOffset>("CreatedAt").CurrentValue = timestamp;
				entry.Property<DateTimeOffset>("UpdatedAt").CurrentValue = timestamp;
			}

			if (entry.State == EntityState.Modified)
			{
				entry.Property<DateTimeOffset>("UpdatedAt").CurrentValue = timestamp;
			}
		}
		
		return base.SaveChangesAsync(cancellationToken);
	}

	private async Task DispatchDomainEvents(CancellationToken ct)
	{
		if (_mediator == null)
			return;
		
		var entityEntries = this.ChangeTracker.Entries<IEntity>().Where(e =>
			e.Entity.GetDomainEvents().Any()).ToList();
		
		var domainEvents  = entityEntries.SelectMany(e => e.Entity.GetDomainEvents()).ToList();
		
		foreach (var domainEvent in domainEvents)
			await _mediator.Publish(domainEvent, ct);
		
		entityEntries.ForEach(e => e.Entity.RemoveDomainEvents());
	}

	private async Task DispatchIntegrationEvents(CancellationToken ct) { }
}
