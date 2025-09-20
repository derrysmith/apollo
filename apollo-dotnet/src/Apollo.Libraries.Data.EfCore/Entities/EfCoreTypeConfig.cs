using Apollo.Libraries.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apollo.Libraries.Data.EfCore.Entities;

public abstract class EfCoreTypeConfig<TEntity, TEntityKey> : IEntityTypeConfiguration<TEntity>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : struct, IEntityKey<TEntityKey>
{
	public void Configure(EntityTypeBuilder<TEntity> builder)
	{
		this.ConfigurePrimaryKey(builder);
		this.ConfigureProperties(builder);
		this.ConfigureTimestamps(builder);
	}

	protected abstract void ConfigureProperties(EntityTypeBuilder<TEntity> builder);

	protected virtual void ConfigurePrimaryKey(EntityTypeBuilder<TEntity> builder)
	{
		// primary key
		builder.HasKey(entity => entity.Id);
		
		// strongly typed id conversions
		builder.Property(entity => entity.Id)
			   .HasConversion(key => key.ToString(), sql => ParseEntityKey(sql))
			   .HasMaxLength(64);
	}

	protected virtual void ConfigureTimestamps(EntityTypeBuilder<TEntity> builder)
	{
	}

	private static TEntityKey ParseEntityKey(string? sql)
		=> TEntityKey.Parse(sql ?? string.Empty);
}