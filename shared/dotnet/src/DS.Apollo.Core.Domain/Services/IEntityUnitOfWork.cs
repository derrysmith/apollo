namespace DS.Apollo.Core.Domain.Services;

public interface IEntityUnitOfWork
{
	Task CommitAsync(CancellationToken ct = default);
}