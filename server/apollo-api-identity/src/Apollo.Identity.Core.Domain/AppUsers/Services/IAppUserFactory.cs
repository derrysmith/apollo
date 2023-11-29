using Apollo.Identity.Core.Domain.AppUsers.Entities;

namespace Apollo.Identity.Core.Domain.AppUsers.Services;

public interface IAppUserFactory
{
	AppUser Create(AppUserProps props);
}