using Apollo.Core.Domain.Identity.Messages;
using Apollo.Libraries.Core.Domain.Entities;

namespace Apollo.Core.Domain.Identity.Entities;

[EntityKey(Prefix = "usr_")]
public record UserProfileId : EntityKey<UserProfileId>;

public class UserProfile : Entity<UserProfileId>, IAggregateRoot, IAggregateRootEventHandler<UserProfileCreated>
{
	private UserProfile() { }

	public string DisplayName { get; private set; } = default!;
	public string Description { get; private set; } = default!;

	public UserProfileEmail? Email { get; private set; }
	public UserProfilePhone? Phone { get; private set; }
	public UserProfileLogin? Login { get; private set; }

	public static UserProfile Create()
	{
		var userProfileCreated = new UserProfileCreated
		{
			UserProfileId = UserProfileId.New(),
			DisplayName   = "Derry Smith",
			Description   = "",
			Email         = new UserProfileEmail("derrysmith@gmail.com", true),
			Phone         = new UserProfilePhone("1234567890", true),
			Login         = new UserProfileLogin("Auth0", "ds|12")
		};

		var userProfile = new UserProfile();
		userProfile.RaiseDomainEvent(userProfileCreated);

		return userProfile;
	}

	void IAggregateRootEventHandler<UserProfileCreated>.Handle(UserProfileCreated domainEvent)
	{
		this.Id          = domainEvent.UserProfileId;
		this.DisplayName = domainEvent.DisplayName;
		this.Description = domainEvent.Description;
		this.Email       = domainEvent.Email;
		this.Phone       = domainEvent.Phone;
		this.Login       = domainEvent.Login;
	}
}
