using Apollo.Libraries.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apollo.Infrastructure.Data.EF;

public abstract class EntityFxTypeConfiguration<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : IEquatable<TEntityKey>
{
	private readonly string? _schema;

	protected EntityFxTypeConfiguration(string? schema = default)
		=> _schema = schema;
	
	public void Configure(EntityTypeBuilder<TEntity> builder)
	{
		// schema
		if (!string.IsNullOrEmpty(_schema))
			builder.Metadata.SetSchema(_schema);
		
		// primary key
		builder.HasKey(e => e.Id);
		
		// columns
		this.ConfigureProperties(builder);
		
		// audit columns
		builder.Property<DateTimeOffset>("CreatedAt").IsRequired();
		builder.Property<string?>("CreatedBy").HasMaxLength(256);
		builder.Property<DateTimeOffset>("UpdatedAt").IsRequired();
		builder.Property<string?>("UpdatedBy").HasMaxLength(256);
		builder.Property<uint>("RowVersion").IsRequired().IsRowVersion();
	}

	protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);
}
