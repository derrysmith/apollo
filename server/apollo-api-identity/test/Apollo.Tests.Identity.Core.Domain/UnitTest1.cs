using Apollo.Core.Domain;
using Apollo.Identity.Core.Domain;
using Apollo.Identity.Core.Domain.AppUsers.Entities;

namespace Apollo.Tests.Identity.Core.Domain;

public class UserProfileFactoryTests
{
	[Fact]
	public void Create_returnsUserProfile()
	{
		// arrange
		var entityKeyFactory = A.Fake<IEntityKeyFactory>();
		A.CallTo(() => entityKeyFactory.New<AppUserKey>())
			.Returns(new AppUserKey("usr_12345"));
        
		var props = new AppUserProps
		{
			FName = "Rocky",
			LName = "Balboa",
			AuthProviderName = "auth0",
			AuthProviderType = "social",
			AuthProviderUserId = "auth0|1234",
			AuthProviderUserName = "rbalboa"
		};

		var validator = new AppUserPropsValidator();
		var factory = new AppUser.Factory(validator, entityKeyFactory);

		// act
		var profile = factory.Create(props);

		// assert
		profile.Id.ToString().ShouldBe("usr_12345");
		profile.FName.ShouldBe(props.FName);
		profile.LName.ShouldBe(props.LName);
		profile.AuthProviderName.ShouldBe(props.AuthProviderName);
		profile.AuthProviderType.ShouldBe(props.AuthProviderType);
		profile.AuthProviderUserId.ShouldBe(props.AuthProviderUserId);
		profile.AuthProviderUserName.ShouldBe(props.AuthProviderUserName);
	}
}

public class CreateUserProfileRequestValidatorTests
{
	[Fact]
	public void Validate_returnsSuccess()
	{
		// arrange
		var props = new AppUserProps
		{
			FName = "Rocky",
			LName = "Balboa",
			AuthProviderName = "auth0",
			AuthProviderType = "social",
			AuthProviderUserId = "auth0|1234",
			AuthProviderUserName = "rbalboa"
		};

		var validator = new AppUserPropsValidator();

		// act
		var result = validator.Validate(props);

		// assert
		Assert.True(result.IsValid);
	}

	[Theory]
	[InlineData("Rocky", "")]
	[InlineData("Rocky", " ")]
	[InlineData("Rocky", null)]
	[InlineData("", "Balboa")]
	[InlineData(" ", "Balboa")]
	[InlineData(null, "Balboa")]
	public void Validate_returnsFailure_whenNamesAreEmpty(string fname, string lname)
	{
		// arrange
		var props = new AppUserProps
		{
			FName = fname,
			LName = lname,
			AuthProviderName = "auth0",
			AuthProviderType = "social",
			AuthProviderUserId = "auth0|1234",
			AuthProviderUserName = "rbalboa"
		};

		var validator = new AppUserPropsValidator();

		// act
		var result = validator.Validate(props);

		// assert
		Assert.False(result.IsValid);
	}

	[Theory]
	[InlineData("auth0", "social", "", "")]
	[InlineData("auth0", "social", " ", " ")]
	[InlineData("auth0", "social", null, null)]
	[InlineData("", "", "auth0|1234", "rbalboa")]
	[InlineData(" ", " ", "auth0|1234", "rbalboa")]
	[InlineData(null, null, "auth0|1234", "rbalboa")]
	public void Validate_returnsFailure_whenAuthInfoIsEmpty(
		string authProviderName,
		string authProviderType,
		string authProviderUserId,
		string authProviderUserName)
	{
		// arrange
		var props = new AppUserProps
		{
			FName = "Rocky",
			LName = "Balboa",
			AuthProviderName = authProviderName,
			AuthProviderType = authProviderType,
			AuthProviderUserId = authProviderUserId,
			AuthProviderUserName = authProviderUserName
		};

		var validator = new AppUserPropsValidator();

		// act
		var result = validator.Validate(props);

		// assert
		Assert.False(result.IsValid);
	}
}