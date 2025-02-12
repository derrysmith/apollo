// using System.Reflection;
// using Apollo.Entities;
//
// namespace Apollo.Tests.Entities;
//
// public class AggregateRootTests;
//
// public class EntityTests;
//
// public class EntityKeyAttributeTests;
//
// public class EntityKeyTests
// {
// 	// UserId.New();
// 	// var userId = new UserId();
// 	// var userId = UserId.Parse("usr_123ABC");
// 	
// 	// [EntityKey(Format = "usr_{0}", GeneratorType = EntityKeyGeneratorType.Ulid)]
// 	// record UserId : EntityKey<UserId>;
// 	
// 	[Fact]
// 	public void ctor_returnsNewInstance()
// 	{
// 		// arrange
// 		
// 		// act
// 		var actual = new UserProfileId();
// 		
// 		// assert
// 		Assert.StartsWith("usr_", actual.ToString());
// 	}
// }
//
// [EntityKey(Format = "usr_{0}", GeneratorType = EntityKeyGeneratorType.SequentialDate)]
// public record UserProfileId : EntityKey<UserProfileId>;