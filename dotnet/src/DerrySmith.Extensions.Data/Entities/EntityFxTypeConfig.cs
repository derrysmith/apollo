using DerrySmith.Extensions.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerrySmith.Extensions.Data.Entities;

public abstract class EntityFxTypeConfig<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : IEntityKey<TEntityKey>
{
	public void Configure(EntityTypeBuilder<TEntity> builder)
	{
		// primary key
		this.ConfigurePrimaryKey(builder);
		
		// properties
		this.ConfigureProperties(builder);
		
		// audit properties
		this.ConfigureTimestamps(builder);
		this.ConfigureRowVersion(builder);
	}

	protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);

	protected virtual void ConfigurePrimaryKey(EntityTypeBuilder<TEntity> builder)
	{
		builder.HasKey(entity => entity.Id);

		// configure conversion for strongly typed entity key
		builder.Property(entity => entity.Id).HasMaxLength(64)
			   .HasConversion(key => key.ToString(), sql => ConvertFromProvider(sql));
	}

	protected virtual void ConfigureTimestamps(EntityTypeBuilder<TEntity> builder)
	{
	}

	protected virtual void ConfigureRowVersion(EntityTypeBuilder<TEntity> builder)
	{
		builder.Property<uint>("RowVersion").IsRowVersion().IsRequired();
	}

	private static TEntityKey ConvertFromProvider(string? sql)
	{
		return TEntityKey.Parse(sql ?? string.Empty);
	}
}