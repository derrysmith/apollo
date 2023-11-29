using Microsoft.EntityFrameworkCore;

namespace Apollo.Identity.Core.Infrastructure.Services;

public abstract class EntityFxCoreRepository<TDbContext>
	where TDbContext : DbContext
{
	protected EntityFxCoreRepository(TDbContext dbContext)
		=> this.DbContext = dbContext;

	protected TDbContext DbContext { get; }
}