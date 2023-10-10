using DS.Apollo.Core.Domain.Entities;

namespace Apollo.Identity.Core.Domain;

public record ProfileKey : EntityKey<Guid>
{
	public ProfileKey(Guid value)
		: base(value)
	{
	}
}