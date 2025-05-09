namespace DerrySmith.Extensions.Domain.Entities;

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
{
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	void Append(TEntity entity);

	void Update(TEntity entity);

	void Remove(TEntityKey id);
}
