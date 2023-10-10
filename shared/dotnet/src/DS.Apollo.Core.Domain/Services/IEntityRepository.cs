using DS.Apollo.Core.Domain.Entities;

namespace DS.Apollo.Core.Domain.Services;

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
	where TEntityKey : IEntityKey
{
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);
	void Append(TEntity entity);
	void Update(TEntity entity);
	void Delete(TEntityKey id);
}