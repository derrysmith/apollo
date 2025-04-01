using DerrySmith.Core.Common.Validation;

namespace DerrySmith.Core.Common.Tests.Validation;

public class VerifyNumberTests
{
	[Theory]
	[InlineData(100, 123)]
	[InlineData(123, 123)]
	public void IsGreaterThan_throwsError_whenArgIsLessThanOrEqual(int arg, int compare)
		=> Should.Throw<ApplicationException>(() => Verify.That(arg).Is.GreaterThan(compare));

	[Theory]
	[InlineData(124, 123)]
	[InlineData(456, 123)]
	public void IsGreaterThan_doesNotThrowError_whenArgIsGreaterThan(int arg, int compare)
		=> Should.NotThrow(() => Verify.That(arg).Is.GreaterThan(compare));
}
