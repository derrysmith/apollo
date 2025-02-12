using Apollo.Libraries.Core.Domain.Entities;
using Apollo.Libraries.Core.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Infrastructure.Data.EF;

public abstract class EntityFxRepository<TEntity, TEntityKey> : IEntityRepository<TEntity, TEntityKey>
	where TEntity : class, IEntity<TEntityKey>
	where TEntityKey : IEquatable<TEntityKey>
{
	protected EntityFxRepository(ApolloDbContext context)
		=> this.DbContext = context;

	public IUnitOfWork UoW => this.DbContext;

	protected ApolloDbContext DbContext { get; }

	public async Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default)
		=> await this.DbContext.Set<TEntity>().SingleAsync(e => e.Id.Equals(id), ct);

	public void Append(TEntity entity)
		=> this.DbContext.Set<TEntity>().Add(entity).State = EntityState.Added;

	public void Update(TEntity entity)
		=> this.DbContext.Set<TEntity>().Update(entity).State = EntityState.Modified;
}