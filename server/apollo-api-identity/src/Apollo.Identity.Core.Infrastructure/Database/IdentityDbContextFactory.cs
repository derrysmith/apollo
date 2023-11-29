using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Apollo.Identity.Core.Infrastructure.Database;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
	public IdentityDbContext CreateDbContext(string[] args)
	{
		var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
		optionsBuilder.UseSqlServer();

		return new IdentityDbContext(optionsBuilder.Options);
	}
}