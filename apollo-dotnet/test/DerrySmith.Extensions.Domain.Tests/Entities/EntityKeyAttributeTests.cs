using DerrySmith.Extensions.Domain.Entities;

namespace DerrySmith.Extensions.Domain.Tests.Entities;

public class EntityKeyTests
{
	[Fact]
	public void New_returnsNewEntityKey()
	{
		// arrange
		const string prefix = "xx_";
		const string suffix = "_xx";
		
		// act
		var actual = EntityKeyTestId.New();
		
		// assert
		actual.ToString().ShouldStartWith(prefix);
		actual.ToString().ShouldEndWith(suffix);
	}

	[EntityKey(Format = "xx_{0}_xx")]
	record EntityKeyTestId : EntityKey<EntityKeyTestId>;
}
