using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using Apollo.Identity.Core.Domain.AppUsers.Services;
using Apollo.Identity.Core.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Identity.Core.Infrastructure.Services;

public class AppUserRepository : EntityFxCoreRepository<IdentityDbContext>, IAppUserRepository
{
	public AppUserRepository(IdentityDbContext context)
		: base(context)
	{
	}

	public async Task<AppUser> GetAsync(AppUserKey id, CancellationToken ct = default)
	{
		return await this.DbContext.AppUsers.SingleAsync(
			usr => usr.Id == id, ct);
	}

	public void Append(AppUser entity)
	{
		this.DbContext.AppUsers.Add(entity);
	}

	public void Update(AppUser entity)
	{
		throw new NotImplementedException();
	}

	public void Delete(AppUserKey id)
	{
		throw new NotImplementedException();
	}
}