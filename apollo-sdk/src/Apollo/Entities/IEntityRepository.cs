namespace Apollo.Entities;

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
	where TEntityKey : IEquatable<TEntityKey>
{
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	void Append(TEntity entity);

	void Update(TEntity entity);

	void Delete(TEntityKey id);
}
