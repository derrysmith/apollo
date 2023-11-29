using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using Apollo.Identity.Core.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Identity.Core.Infrastructure.Database;

// Database
// Database/Migrations

public class IdentityDbContext : DbContext
{
	public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
		: base(options)
	{
	}

	public DbSet<AppUser> AppUsers { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new AppUserEntityTypeConfiguration());
	}
}