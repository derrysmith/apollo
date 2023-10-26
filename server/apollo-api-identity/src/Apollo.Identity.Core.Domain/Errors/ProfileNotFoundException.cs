namespace Apollo.Identity.Core.Domain.Errors;

public class ProfileNotFoundException : ApplicationException
{
	public ProfileNotFoundException(ProfileKey profileId, Exception? innerException = default)
		: base($"profile '{profileId}' could not be found", innerException)
	{
		this.ProfileId = profileId;
	}

	public ProfileKey ProfileId { get; }
}