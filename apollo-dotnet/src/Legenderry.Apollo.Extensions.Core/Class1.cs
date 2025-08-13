namespace Legenderry.Apollo.Extensions.Core.Entities;

public interface IEntity;

public interface IEntity<out TEntityKey> : IEntity
{
	TEntityKey Id { get; }
}

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
{
	Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default);
	
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	void Append(TEntity entity);

	void Update(TEntity entity);

	void Remove(TEntityKey id);
}

public interface IAggregateRoot;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	public TEntityKey Id { get; protected set; } = default!;
}

public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot;