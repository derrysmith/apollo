using DS.Apollo.Core.Domain.Entities;

namespace DS.Tests.Apollo.Core.Domain.Entities;

public class EntityKeyTests
{
	[Fact]
	public void operatorToStringType_returnsString()
	{
		// arrange
		var testEntityKey = new TestEntityKey(123);
		
		// act
		string testEntityKeyVal = testEntityKey;
		
		Assert.Equal("123", testEntityKeyVal);
	}

	[Fact]
	public void operatorToValueType_returnsValue()
	{
		// arrange
		var testEntityKey = new TestEntityKey(123);
		
		// act
		int testEntityKeyVal = testEntityKey;
		
		Assert.Equal(123, testEntityKeyVal);
	}
}

internal record TestEntityKey : EntityKey<int>
{
	public TestEntityKey(int value) : base(value)
	{
	}
}