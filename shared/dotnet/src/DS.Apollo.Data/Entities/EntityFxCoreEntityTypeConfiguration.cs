using DS.Apollo.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DS.Apollo.Data.Entities;

public abstract class EntityFxCoreEntityTypeConfiguration<T, TK> : IEntityTypeConfiguration<T>
	where T : class, IEntity<TK>
{
	public void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(e => e.Id);

		builder.Property(e => e.Id).HasColumnName("id")
			.ValueGeneratedNever().IsRequired();

		builder.Property(e => e.CreatedAt).HasColumnName("created_at")
			.ValueGeneratedNever().IsRequired();

		builder.Property(e => e.UpdatedAt).HasColumnName("updated_at")
			.ValueGeneratedNever().IsRequired();

		this.ConfigureEntity(builder);
	}
	
	protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}