namespace DerrySmith.Apollo.Extensions.Core.Entities;

public interface IEntityRepository<TEntity, in TEntityKey>
{
	Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default);
	
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	void Append(TEntity entity);

	void Update(TEntity entity);

	void Remove(TEntityKey id);
}