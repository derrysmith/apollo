using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

public class EntityKeyTests
{
	[EntityKey(Prefix = "abc_", Suffix = "_xyz")]
	public record TestKey : EntityKey<TestKey>;
	
	[Fact]
	public void New_returnsEntityKey()
	{
		// act
		var entityKey = TestKey.New();

		// assert
		var entityKeyString = entityKey.ToString();
		entityKeyString.ShouldStartWith("abc_");
		entityKeyString.ShouldEndWith("_xyz");
	}

	[Fact]
	public void Parse_returnsEntityKey()
	{
		// arrange
		var value = "abc_01K36WWP88D1BDKK0J79G83V49_xyz";

		// act
		var entityKey = TestKey.Parse(value);

		// assert
		var entityKeyString = entityKey.ToString();
		entityKeyString.ShouldBe(value);
	}

	[Fact]
	public void TryParse_returnsTrue_whenInputIsValid()
	{
		// arrange
		var value = "abc_01K36WWP88D1BDKK0J79G83V49_xyz";

		// act
		var parse = TestKey.TryParse(value, out _);

		// assert
		parse.ShouldBeTrue();
	}

	[Fact]
	public void TryParse_returnsFalse_whenInputIsInvalid()
	{
		// arrange
		var value = "abc_01K36WWP88D1BDKK0J79G83V4_xyz";

		// act
		var parse = TestKey.TryParse(value, out _);

		// assert
		parse.ShouldBeFalse();
	}
}