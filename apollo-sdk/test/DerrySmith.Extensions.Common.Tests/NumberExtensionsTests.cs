using DerrySmith.Extensions.Common.Utilities;

namespace DerrySmith.Extensions.Common.Tests;

public class NumberExtensionsTests
{
	[Theory]
	[InlineData(0, "Zero")]
	[InlineData(1, "One")]
	[InlineData(10, "Ten")]
	[InlineData(16, "Sixteen")]
	[InlineData(20, "Twenty")]
	[InlineData(23, "Twenty-Three")]
	[InlineData(50, "Fifty")]
	[InlineData(99, "Ninety-Nine")]
	[InlineData(100, "One Hundred")]
	[InlineData(101, "One Hundred and One")]
	[InlineData(123, "One Hundred and Twenty-Three")]
	[InlineData(999, "Nine Hundred and Ninety-Nine")]
	[InlineData(1000, "One Thousand")]
	[InlineData(1001, "One Thousand, One")]
	[InlineData(1234, "One Thousand, Two Hundred and Thirty-Four")]
	[InlineData(1234567, "One Million, Two Hundred and Thirty-Four Thousand, Five Hundred and Sixty-Seven")]
	[InlineData(123456789, "One Hundred and Twenty-Three Million, Four Hundred and Fifty-Six Thousand, Seven Hundred and Eighty-Nine")]
	[InlineData(long.MaxValue, "Nine Quintillion, Two Hundred and Twenty-Three Quadrillion, Three Hundred and Seventy-Two Trillion, Thirty-Six Billion, Eight Hundred and Fifty-Four Million, Seven Hundred and Seventy-Five Thousand, Eight Hundred and Seven")]
	public void ToEnglish_returnsEnglishRepresentationOfNumber(long target, string expected)
	{
		// act
		var actual = target.ToEnglish();
		
		// assert
		actual.ShouldBe(expected);
	}
}
