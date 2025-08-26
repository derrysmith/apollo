using DerrySmith.Extensions.Core.Entities;
using DerrySmith.Extensions.Data.EntityFx.Database;
using Microsoft.EntityFrameworkCore;

namespace DerrySmith.Extensions.Data.EntityFx.Entities;

public abstract class EntityFxRepository<TEntity, TEntityKey, TDbContext> : IEntityRepository<TEntity, TEntityKey>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : IEntityKey<TEntityKey>, IEquatable<TEntityKey>
	where TDbContext : EntityFxDbContext
{
	protected TDbContext DbContext { get; }

	protected EntityFxRepository(TDbContext context)
	{
		this.DbContext = context;
	}

	public virtual async Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default)
	{
		return await this.DbContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id.Equals(id), ct);
	}

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
		throw new NotImplementedException();
	}
}