using System.Reflection;
using DerrySmith.Extensions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DerrySmith.Extensions.Domain.EntityFrameworkCore;

public abstract class EntityFxCoreDbContext : DbContext
{
	public const string CreatedAtShadowProperty  = "CreatedAt";
	public const string UpdatedAtShadowProperty  = "UpdatedAt";
	public const string RowVersionShadowProperty = "RowVersion";

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
	{
		foreach (var entry in this.ChangeTracker.Entries<IEntity>())
		{
			switch (entry)
			{
				case { State: EntityState.Deleted }:
				case { State: EntityState.Modified }:
					entry.Property<DateTimeOffset>(UpdatedAtShadowProperty).CurrentValue = DateTimeOffset.UtcNow;

					break;

				case { State: EntityState.Added }:
					entry.Property<DateTimeOffset>(CreatedAtShadowProperty).CurrentValue = DateTimeOffset.UtcNow;
					entry.Property<DateTimeOffset>(UpdatedAtShadowProperty).CurrentValue = DateTimeOffset.UtcNow;

					break;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);

		// singular table names
		configurationBuilder.Conventions.Remove<TableNameFromDbSetConvention>();
		configurationBuilder.Properties<string>().AreUnicode();
		configurationBuilder.Properties<decimal>().HavePrecision(24, 8);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		foreach (var assembly in this.GetAssembliesContainingTypeConfigurations())
			modelBuilder.ApplyConfigurationsFromAssembly(assembly);
	}

	protected abstract IEnumerable<Assembly> GetAssembliesContainingTypeConfigurations();
}
