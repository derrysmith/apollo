using DS.Apollo.Core.Domain.Entities;

namespace DS.Apollo.Core.Domain.Services;

public interface IEntityRepositoryReader<T, in TK>
	where T : IEntity<TK>
{
	Task<T> GetAsync(TK id, CancellationToken ct);
}