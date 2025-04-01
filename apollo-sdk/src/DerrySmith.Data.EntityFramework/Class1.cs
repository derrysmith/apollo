using Microsoft.EntityFrameworkCore;

namespace DerrySmith.Data.EntityFramework.Repositories;

public interface IRepository<TEntity, in TEntityId>
{
	Task<TEntity> GetAsync(TEntityId id, CancellationToken ct = default);
}

public abstract class EntityFrameworkCoreRepository;

public class EntityNotFoundException : ApplicationException
{
	public EntityNotFoundException(Type entityType, string? message = default) : base(message)
		=> this.EntityType = entityType;

	public Type EntityType { get; private set; }
}

public class EfCoreEntityNotUniqueException;

public abstract class EfCoreRepository<TEntity, TEntityId, TDbContext> : IRepository<TEntity, TEntityId>
	where TEntity : class
	where TEntityId : IEquatable<TEntityId>
	where TDbContext : DbContext
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="context"></param>
	protected EfCoreRepository(TDbContext context)
		=> this.DbContext = context;

	/// <summary>
	/// 
	/// </summary>
	protected TDbContext DbContext { get; private set; }

	public async Task<TEntity> GetAsync(TEntityId id, CancellationToken ct = default)
	{
		var entity = await this.DbContext.Set<TEntity>()
							   .FindAsync(keyValues: [id], cancellationToken: ct);

		return entity ?? throw new EntityNotFoundException(typeof(TEntity));
	}
}
