using DS.Apollo.Core.Domain.Entities;

namespace DS.Apollo.Core.Domain.Services;

public interface IEntityRepositoryDeleter<T, in TK>
	where T : IEntity<TK>
{
	void Delete(TK id);
}