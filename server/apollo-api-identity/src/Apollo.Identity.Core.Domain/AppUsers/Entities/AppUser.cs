using Apollo.Core.Domain;

namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public partial class AppUser : Entity<AppUserKey>
{
	protected AppUser()
	{
	}
		
	public string FName { get; private set; } = default!;
	public string LName { get; private set; } = default!;

	public string AuthProviderName { get; private set; } = default!;
	public string AuthProviderType { get; private set; } = default!;
	public string AuthProviderUserId { get; private set; } = default!;
	public string AuthProviderUserName { get; private set; } = default!;

	public AppUserEmail? Email { get; private set; }
	public AppUserPhone? Phone { get; private set; }
}