using Apollo.Identity.Core.Domain.AppUsers.Entities;

namespace Apollo.Identity.Core.Domain.AppUsers.Services;

public interface IAppUserRepository
{
	Task<AppUser> GetAsync(AppUserKey id, CancellationToken ct = default);
	void Append(AppUser entity);
	void Update(AppUser entity);
	void Delete(AppUserKey id);
}