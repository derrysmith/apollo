using Apollo.Core.Domain;

namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

[EntityKey("usr")]
public record AppUserKey : EntityKey
{
	public AppUserKey(string value) : base(value)
	{
	}
}