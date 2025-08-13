namespace Legenderry.Apollo.Extensions.Core.Tests.Entities;

public class EntityKeyTests
{
	[Fact]
	public void EntityKey_startsWithPrefix()
	{
		// arrange
		var expect    = "mid_";
		var entityKey = UnitTestId.New();

		// act
		var actual = entityKey.ToString();

		// assert
		Assert.StartsWith(expect, actual);
	}

	[Fact]
	public void EntityKey_endsWithSuffix()
	{
		// arrange
		var expect    = "_key";
		var entityKey = UnitTestId.New();

		// act
		var actual = entityKey.ToString();

		// assert
		Assert.EndsWith(expect, actual);
	}
}