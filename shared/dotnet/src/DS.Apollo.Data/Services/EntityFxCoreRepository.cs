using DS.Apollo.Data.Database;

namespace DS.Apollo.Data.Services;

public abstract class EntityFxCoreRepository<T>
	where T : EntityFxCoreDbContext
{
	protected EntityFxCoreRepository(T dbContext)
		=> this.DbContext = dbContext;

	protected T DbContext { get; }
}