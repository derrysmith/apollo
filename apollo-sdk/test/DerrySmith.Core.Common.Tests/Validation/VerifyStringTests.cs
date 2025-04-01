using DerrySmith.Core.Common.Validation;

namespace DerrySmith.Core.Common.Tests.Validation;

public class VerifyStringTests
{
	[Theory]
	[InlineData(" ")]
	[InlineData("x")]
	public void IsNullOrEmpty_throwsError_whenArgIsNotNullNorEmpty(string arg)
		=> Should.Throw<ApplicationException>(() => Verify.That(arg).Is.NullOrEmpty());

	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public void IsNullOrEmpty_doesNotThrowError_whenArgIsNullOrEmpty(string arg)
		=> Should.NotThrow(() => Verify.That(arg).Is.NullOrEmpty());

	[Theory]
	[InlineData("x")]
	[InlineData("xy")]
	[InlineData("xyz")]
	public void IsNullOrWhiteSpace_throwsError_whenArgIsNotNullNorWhiteSpace(string arg)
		=> Should.Throw<ApplicationException>(() => Verify.That(arg).Is.NullOrWhiteSpace());
	
	[Theory]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(null)]
	public void IsNullOrWhiteSpace_doesNotThrowError_whenArgIsNullOrWhiteSpace(string arg)
		=> Should.NotThrow(() => Verify.That(arg).Is.NullOrWhiteSpace());
	
	[Theory]
	[InlineData("")]
	[InlineData(null)]
	public void IsNotNullOrEmpty_throwsError_whenArgIsNullOrEmpty(string arg)
		=> Should.Throw<ApplicationException>(() => Verify.That(arg).IsNot.NullOrEmpty());
	
	[Theory]
	[InlineData(" ")]
	[InlineData("x")]
	public void IsNotNullOrEmpty_doesNotThrowError_whenArgIsNotNullNorEmpty(string arg)
		=> Should.NotThrow(() => Verify.That(arg).IsNot.NullOrEmpty());
	
	[Theory]
	[InlineData("")]
	[InlineData(" ")]
	[InlineData(null)]
	public void IsNotNullOrWhiteSpace_throwsError_whenArgIsNullOrWhiteSpace(string arg)
		=> Should.Throw<ApplicationException>(() => Verify.That(arg).IsNot.NullOrWhiteSpace());
	
	[Theory]
	[InlineData("x")]
	[InlineData("xy")]
	[InlineData("xyz")]
	public void IsNotNullOrWhiteSpace_doesNotThrowError_whenArgIsNotNullNorWhiteSpace(string arg)
		=> Should.NotThrow(() => Verify.That(arg).IsNot.NullOrWhiteSpace());
}
