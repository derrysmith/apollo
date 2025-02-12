using Apollo.Core.Domain.Identity.Entities;
using Apollo.Libraries.Core.Domain.Messages;

namespace Apollo.Core.Domain.Identity.Messages;

// - create default contact for created user profile
// - update authentication service with apollo metadata for this user
// - send out welcome email to created user profile
public record UserProfileCreated : IDomainEvent
{
	public required UserProfileId UserProfileId { get; init; }

	public required string DisplayName { get; init; }
	public required string Description { get; init; }

	public UserProfileEmail? Email { get; set; }
	public UserProfilePhone? Phone { get; set; }
	public UserProfileLogin? Login { get; set; }
}
