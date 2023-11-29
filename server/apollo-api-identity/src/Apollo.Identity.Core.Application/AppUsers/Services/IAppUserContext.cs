using Apollo.Identity.Core.Domain.AppUsers.Services;

namespace Apollo.Identity.Core.Application.AppUsers.Services;

public interface IAppUserContext
{
	IAppUserRepository AppUsers { get; }
	Task CommitAsync(CancellationToken ct = default);
}