using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

public class EntityKeyTests
{
	[Fact]
	public void New_returnsEntityKey()
	{
	}

	[Fact]
	public void Parse_returnsEntityKey()
	{
	}

	[Fact(DisplayName = "Parse: throws error if string can't be parsed into ulid")]
	public void Parse_throwsError_whenValueIsInvalid()
	{
		// arrange
		const string entityKeyValue = "usr_01JYJQCH43571R5QHQ4FM4WZ8";

		// act
		var ex = Assert.Throws<EntityKeyException<UserAccountId>>(() => UserAccountId.Parse(entityKeyValue));

		// assert
		ex.Value.ShouldBe(entityKeyValue);
	}

	[Fact(DisplayName = ".Parse: throws error if guid can't be parsed into ulid")]
	public void Parse_throwsError_whenGuidValueIsNotConvertibleToUlid()
	{
		// arrange
		//const string input = "AC8C88E0-6458-4795-B7D5-230E9E6D82DA";
		const string input = "AC8C88E0-6458-4795-B7D5-230E9E6D82DF";
		var          guid  = Guid.Parse(input);

		// act
		var ex = Assert.Throws<EntityKeyException<UserAccountId>>(() => UserAccountId.Parse(guid));

		// assert
		Assert.Equal(input, guid.ToString("N"));
	}

	public void TryParse_returnsTrue()
	{
	}

	public void TryParse_returnsFalse_whenValueIsInvalid()
	{
	}
}

public class EntityKeyProviderTests
{
	[Fact]
	public void New_returnsEntityKey()
	{
		// arrange

		// act
		var userAccountId = UserAccountId.New();

		// assert
		Assert.Equal("", userAccountId.ToString());
	}

	[Fact]
	public void Parse_returnsEntityKey()
	{
		// arrange
		const string entityKeyValue = "usr_01JYJQCH43571R5QHQ4FM4WZ82";

		// act
		var entityKey = UserAccountId.Parse(entityKeyValue);

		// assert
		Assert.Equal(entityKeyValue, entityKey.ToString());
	}

	[Fact]
	public void Parse_throwsError_whenValueIsNotValid()
	{
		// arrange
		const string entityKeyValue = "usr_01JYJQCH43571R5QHQ4FM4WZ8";

		// act
		var ex = Assert.Throws<EntityKeyException<UserAccountId>>(() => UserAccountId.Parse(entityKeyValue));

		// assert
		Assert.Equal(entityKeyValue, ex.Value);
	}

	[Fact]
	public void TryParse_returnsTrue()
	{
		// arrange
		const string entityKeyValue = "usr_01JYJQCH43571R5QHQ4FM4WZ82";

		// act
		var success = UserAccountId.TryParse(entityKeyValue, out _);

		// assert
		Assert.True(success);
	}
}

[EntityKey(Prefix = "usr_")]
public record UserAccountId : EntityKey<UserAccountId>;