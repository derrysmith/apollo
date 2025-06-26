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
		var ex = Assert.Throws<EntityKeyException<UnitTestEntityId>>(() => UnitTestEntityId.Parse(entityKeyValue));

		// assert
		ex.Value.ShouldBe(entityKeyValue);
	}
}

[EntityKey(Prefix = "usr_")]
public record UnitTestEntityId : EntityKey<UnitTestEntityId>;