using Apollo.Libraries.Core.Domain.Services;

namespace Apollo.Libraries.Core.Domain.Entities;

public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
{
	IUnitOfWork UoW { get; }
	
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	void Append(TEntity entity);

	void Update(TEntity entity);
}
