using DerrySmith.Apollo.Extensions.Core.Entities;
using Xunit.Abstractions;

namespace DerrySmith.Apollo.Extensions.Core.Tests;

public class UnitTest(ITestOutputHelper output)
{
	[Fact]
	public void Test1()
	{
		// arrange
		var id = UnitTestId.New();
		
		// assert
		Assert.StartsWith("key_", id.ToString());
		Assert.EndsWith("_xyz", id.ToString());
	}
}

[EntityKey(Prefix = "key_", Suffix = "_xyz")]
public readonly partial record struct UnitTestId;
