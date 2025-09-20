using Apollo.Libraries.Core.DateTime;

namespace Apollo.Libraries.Core.Tests.DateTime;

public class DateTimeExtensionsTests
{
	[Fact]
	public void GetAge_returnsAgeInYears()
	{
		// arrange
		var birthdate = DateOnly.Parse("1975-04-30");
		var date      = DateOnly.Parse("2025-09-20");
		var provider  = new DateTimeProvider();
		
		// act
		var actual = birthdate.GetAge(date, provider);
		
		// assert
		Assert.Equal(50, actual);
	}
}