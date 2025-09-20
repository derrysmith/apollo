using Apollo.Libraries.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Libraries.Data.EfCore.Entities;

public abstract class EfCoreRepository<TEntity, TEntityKey, TDbContext> : IEntityRepository<TEntity, TEntityKey>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : IEquatable<TEntityKey>
	where TDbContext : DbContext
{
	protected TDbContext DbContext { get; }

	protected EfCoreRepository(TDbContext context) => this.DbContext = context;

	public virtual async Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default)
	{
		return await this.DbContext.Set<TEntity>().SingleAsync(entity => entity.Id.Equals(id), ct);
	}

	public virtual async Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default)
	{
		return await this.DbContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id.Equals(id), ct);
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