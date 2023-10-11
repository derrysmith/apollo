using DS.Apollo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DS.Apollo.Data;

public abstract class EntityFxCoreDbContext : DbContext
{
	protected EntityFxCoreDbContext(DbContextOptions options, string? schema = default)
		: base(options)
	{
		this.DefaultSchema = schema ?? "dbo";
	}

	protected string DefaultSchema { get; }

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		// add audit timestamps
		var currentDateTime = DateTimeOffset.UtcNow;

		foreach (var entry in this.ChangeTracker.Entries<IEntity>())
		{
			switch (entry)
			{
				case { State: EntityState.Added }:
					entry.Property(e => e.CreatedAt).CurrentValue = currentDateTime;
					entry.Property(e => e.UpdatedAt).CurrentValue = currentDateTime;
					break;
				case { State: EntityState.Modified }:
					entry.Property(e => e.UpdatedAt).CurrentValue = currentDateTime;
					break;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}