using Apollo.Identity.Core.Application.AppUsers.Services;
using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Services;
using Apollo.Identity.Core.Infrastructure.Database;

namespace Apollo.Identity.Core.Infrastructure.Services;

public class AppUserUnitOfWork : IAppUserContext
{
	private readonly IdentityDbContext _context;

	public AppUserUnitOfWork(IdentityDbContext context, IAppUserRepository repository)
	{
		_context = context;
		this.AppUsers = repository;
	}
	
	public IAppUserRepository AppUsers { get; }
	
	public Task CommitAsync(CancellationToken ct = default)
	{
		return _context.SaveChangesAsync(ct);
	}
}