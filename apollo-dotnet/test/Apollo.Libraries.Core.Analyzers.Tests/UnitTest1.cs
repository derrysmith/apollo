using Apollo.Libraries.Core.Entities;

namespace Apollo.Libraries.Core.Analyzers.Tests;

public class UnitTest1
{
	[Fact]
	public void Test1()
	{
		var idx = UserId.New();
		var str = idx.ToString();
		
		Assert.StartsWith("usr_", str);
		Assert.EndsWith("_xyz", str);

		var g = idx.ToGuid();
		var u = new Ulid(g);
		
		Assert.Equal($"usr_{u}_xyz", str);
	}
}

[EntityKey(Prefix = "usr_", Suffix = "_xyz")]
public readonly partial record struct UserId;