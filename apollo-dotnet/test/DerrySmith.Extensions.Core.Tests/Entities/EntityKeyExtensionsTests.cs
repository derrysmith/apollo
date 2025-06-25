using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Tests.Entities;

public class EntityKeyExtensionsTests
{
	[Fact]
	public void GetEntityKeyAttribute_returnsAttribute()
	{
		// arrange
		const string prefix = "xyz_";
		
		// act
		var attribute = typeof(EntityKeyWithAttribute).GetEntityKeyAttribute();
		
		// assert
		Assert.Equal(prefix, attribute.Prefix);
	}

	[Fact]
	public void GetEntityKeyAttribute_returnsNewAttribute_whenNotAttributedToType()
	{
		// arrange
		// act
		var attribute = typeof(EntityKeyWithoutAttribute).GetEntityKeyAttribute();
		
		// assert
		Assert.Empty(attribute.Prefix);
	}

	[EntityKey(Prefix = "xyz_")]
	record EntityKeyWithAttribute : EntityKey<EntityKeyWithAttribute>;

	record EntityKeyWithoutAttribute : EntityKey<EntityKeyWithoutAttribute>;
}