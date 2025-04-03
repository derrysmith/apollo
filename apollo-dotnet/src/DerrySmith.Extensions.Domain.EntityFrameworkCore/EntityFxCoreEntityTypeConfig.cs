using DerrySmith.Extensions.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerrySmith.Extensions.Domain.EntityFrameworkCore;

public abstract class EntityFxCoreEntityTypeConfig<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity>
	where TEntity : Entity<TEntityKey>
{
	private readonly string _schema;

	protected EntityFxCoreEntityTypeConfig(string schema)
		=> _schema = schema;

	public void Configure(EntityTypeBuilder<TEntity> builder)
	{
		// schema
		builder.Metadata.SetSchema(_schema);

		// primary key
		builder.HasKey(entity => entity.Id);

		// columns
		this.ConfigureProperties(builder);

		builder.Property<DateTimeOffset>(EntityFxCoreDbContext.CreatedAtShadowProperty).IsRequired();
		builder.Property<DateTimeOffset>(EntityFxCoreDbContext.UpdatedAtShadowProperty).IsRequired();
		builder.Property<uint>(EntityFxCoreDbContext.RowVersionShadowProperty).IsRequired().IsRowVersion();
	}

	protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}
