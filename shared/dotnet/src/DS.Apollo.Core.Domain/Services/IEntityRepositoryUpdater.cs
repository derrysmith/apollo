using DS.Apollo.Core.Domain.Entities;

namespace DS.Apollo.Core.Domain.Services;

public interface IEntityRepositoryUpdater<in T>
	where T : IEntity
{
	void Update(T entity);
}