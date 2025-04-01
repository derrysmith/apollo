using DerrySmith.Extensions.Domain.Entities;

namespace DerrySmith.Extensions.Domain.Tests.Entities;

public class EntityKeyTests
{
	private readonly ITestOutputHelper _output;

	public EntityKeyTests(ITestOutputHelper output)
	{
		_output = output;
	}

	[Fact]
	public void Test()
	{
		for (var x = 0; x < 12; x++)
			_output.WriteLine("{0}", UserId.New());
	}
}

[EntityKey(Format = "tm_{0}")]
public record UserId : EntityKey<UserId>;