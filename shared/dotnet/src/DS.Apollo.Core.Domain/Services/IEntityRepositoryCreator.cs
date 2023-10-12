using DS.Apollo.Core.Domain.Entities;

namespace DS.Apollo.Core.Domain.Services;

public interface IEntityRepositoryCreator<in T>
	where T : IEntity
{
	void Append(T entity);
}