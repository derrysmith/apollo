using Apollo.Identity.Core.Domain.Models;
using DS.Apollo.Core.Domain.Entities;

namespace Apollo.Identity.Core.Domain;

public class Profile : Entity<ProfileKey>
{
	public virtual string FirstName { get; private set; } = default!;
	public virtual string LastName { get; private set; } = default!;
	
	public virtual ProfileEmail? Email { get; private set; }
	public virtual ProfilePhone? Phone { get; private set; }
	public virtual ProfileLogin? Login { get; private set; }
}