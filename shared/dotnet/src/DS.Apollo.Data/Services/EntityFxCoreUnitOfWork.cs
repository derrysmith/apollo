using DS.Apollo.Core.Domain.Services;
using DS.Apollo.Data.Database;

namespace DS.Apollo.Data.Services;

public abstract class EntityFxCoreUnitOfWork<T> : IEntityUnitOfWork
	where T : EntityFxCoreDbContext
{
	protected EntityFxCoreUnitOfWork(T dbContext)
		=> this.DbContext = dbContext;

	protected T DbContext { get; }

	public Task CommitAsync(CancellationToken ct = default)
		=> this.DbContext.SaveChangesAsync(ct);
}