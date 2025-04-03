using DerrySmith.Extensions.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DerrySmith.Extensions.Domain.EntityFrameworkCore;

public abstract class EntityFxCoreRepository<TEntity, TEntityKey, TDbContext> : IEntityRepository<TEntity, TEntityKey>
	where TEntity : Entity<TEntityKey>
	where TEntityKey : IEquatable<TEntityKey>
	where TDbContext : DbContext
{
	protected EntityFxCoreRepository(TDbContext context)
		=> this.DbContext = context;

	protected TDbContext DbContext { get; }

	public virtual async Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default)
	{
		return await this.DbContext.Set<TEntity>().SingleAsync(entity => entity.Id.Equals(id), ct);
	}

	public virtual void Append(TEntity entity)
	{
		this.DbContext.Set<TEntity>().Add(entity).State = EntityState.Added;
	}

	public virtual void Update(TEntity entity)
	{
		this.DbContext.Set<TEntity>().Update(entity).State = EntityState.Modified;
	}

	public virtual void Remove(TEntityKey id)
	{
		var entity = this.DbContext.Set<TEntity>().Find(id);

		// should we throw or just no-op
		if (entity is null) return;

		this.DbContext.Set<TEntity>().Remove(entity);
	}
}
