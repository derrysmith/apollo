using Apollo.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Services;
using FluentValidation;

namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public partial class AppUser
{
	public class Factory : IAppUserFactory
	{
		//private readonly IEntityKeyFactory _entityKeyFactory;
		private readonly IValidator<AppUserProps> _validator;

		public Factory(IValidator<AppUserProps> validator)
		{
			_validator = validator;
			//_entityKeyFactory = entityKeyFactory;
		}

		public AppUser Create(AppUserProps props)
		{
			// validate request
			_validator.ValidateAndThrow(props);

			var profile = new AppUser
			{
				Id = new AppUserKey($"usr_{Guid.NewGuid():N}".ToLower()),
					
				FName = props.FName!,
				LName = props.LName!,
					
				AuthProviderName = props.AuthProviderName!,
				AuthProviderType = props.AuthProviderType!,
				AuthProviderUserId = props.AuthProviderUserId!,
				AuthProviderUserName = props.AuthProviderUserName!
			};

			if (!string.IsNullOrWhiteSpace(props.EmailAddress))
				profile.Email = new AppUserEmail(props.EmailAddress, props.EmailIsVerified ?? false);

			if (!string.IsNullOrWhiteSpace(props.PhoneNumber))
				profile.Phone = new AppUserPhone(props.PhoneNumber, props.PhoneIsVerified ?? false);

			return profile;
		}
	}
}