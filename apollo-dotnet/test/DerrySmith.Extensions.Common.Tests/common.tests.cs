using DerrySmith.Extensions.Common.Collections.Generic;
using DerrySmith.Extensions.Common.DateTime;

namespace DerrySmith.Extensions.Common.Tests;

public class PageExtensionsTests
{
	[Fact]
	public void Paged_returnsPage_withSource()
	{
		// arrange
		var source = Enumerable.Range(1, 100);
		
		// act
		var page = source.Paged(4, 30);
		
		// assert
		page.Count.ShouldBe(10);
		page.CurrentPage.ShouldBe(4);
		page.CurrentSize.ShouldBe(30);
		page.HasNextPage.ShouldBeFalse();
		page.HasPrevPage.ShouldBeTrue();
		page.TotalItems.ShouldBe(100);
		page.TotalPages.ShouldBe(4);
	}

	[Fact]
	public void Paged_returnsPage_withSubset()
	{
		// arrange
		var source = Enumerable.Range(1, 100).ToList();
		var subset = source.Skip(0).Take(10);
		
		// act
		var page = subset.Paged(1, 10, source.Count);
		
		// assert
		page.Count.ShouldBe(10);
		page.CurrentPage.ShouldBe(1);
		page.CurrentSize.ShouldBe(10);
		page.HasNextPage.ShouldBeTrue();
		page.HasPrevPage.ShouldBeFalse();
		page.TotalItems.ShouldBe(100);
		page.TotalPages.ShouldBe(10);
	}
}

public class DateTimeExtensionsTests
{
	[Theory]
	[InlineData("1975-01-01", "2025-01-01", 50)]
	[InlineData("1980-01-31", "2025-02-01", 45)]
	[InlineData("1985-12-30", "2025-12-31", 40)]
	public void Age_returnsAge_whenBirthdateIsBeforeDate(string bdate, string today, int expect)
	{
		// arrange
		var dob = System.DateTime.Parse(bdate);
		var now = System.DateTime.Parse(today);
		
		// act
		var age = dob.Age(now);
		
		// assert
		age.ShouldBe(expect);
	}

	[Theory]
	[InlineData("1975-04-30", "2025-01-01", 49)]
	[InlineData("1980-02-01", "2025-01-31", 44)]
	[InlineData("1985-12-31", "2025-12-30", 39)]
	public void Age_returnsAge_whenBirthdateIsAfterDate(string bdate, string today, int expect)
	{
		// arrange
		var dob = System.DateTime.Parse(bdate);
		var now = System.DateTime.Parse(today);
		
		// act
		var age = dob.Age(now);
		
		// assert
		age.ShouldBe(expect);
	}
}