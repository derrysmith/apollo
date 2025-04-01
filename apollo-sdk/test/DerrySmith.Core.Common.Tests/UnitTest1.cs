using DerrySmith.Core.Common.Dates;

namespace DerrySmith.Core.Common.Tests;

public class DateTimeExtensionsTests
{
	[Fact]
	public void Yesterday_returnsPreviousDay()
	{
		// arrange
		var today = new DateTimeOffset(2025, 4, 30, 0, 0, 0, TimeSpan.Zero);
		
		// act
		var yesterday = today.LastYear();
		
		// assert
		yesterday.Year.ShouldBe(2024);
		yesterday.Month.ShouldBe(4);
		yesterday.Day.ShouldBe(30);
	}
}
//
// public class VerifyNumberTests { }
//
// public class UnitTest1
// {
// 	[Theory]
// 	[InlineData(" ")]
// 	[InlineData("a")]
// 	public void IsNullOrEmpty_throwsError_whenArgIsNotEmpty(string arg)
// 	{
// 		// act/assert
// 		Should.Throw<ApplicationException>(() => Verify.That(arg).Is.NullOrEmpty());
// 	}
//
// 	[Theory]
// 	[InlineData(" ")]
// 	[InlineData("a")]
// 	public void IsNotNullOrEmpty_doesNotThrowError_whenArgIsNotEmpty(string arg)
// 	{
// 		// act/assert
// 		Should.NotThrow(() => Verify.That(arg).IsNot.NullOrEmpty());
// 	}
//
// 	[Theory]
// 	[InlineData("")]
// 	[InlineData(null)]
// 	public void IsNotNullOrEmpty_throwsError_whenArgIsEmpty(string? arg)
// 	{
// 		// act/assert
// 		Should.Throw<ApplicationException>(() => Verify.That(arg).IsNot.NullOrEmpty());
// 	}
//
// 	[Theory]
// 	[InlineData("")]
// 	[InlineData(" ")]
// 	[InlineData(null)]
// 	public void IsNotNullOrWhiteSpace_throwsError_whenArgIsEmpty(string? arg)
// 	{
// 		// act/assert
// 		Should.Throw<ApplicationException>(() => Verify.That(arg).IsNot.NullOrWhiteSpace());
// 	}
// }
