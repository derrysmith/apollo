namespace Apollo.Libraries.Core.Domain.Services;

public interface IUnitOfWork
{
	Task CommitAsync(CancellationToken ct = default);
}
