namespace Legenderry.Apollo.Extensions.Core.Tests.Pagination;

public class PageTests
{
	[Fact]
	public void ctor_groupsIntoPages()
	{
		// arrange
		var target = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		
		// act
		var actual = new Page<int>(target, 1, 3);
		
		// assert
		Assert.Equal(3, actual.Count);
		Assert.Equal(1, actual.CurrentPage);
		Assert.Equal(3, actual.CurrentPageSize);
		Assert.Equal(10, actual.TotalItems);
		Assert.Equal(4, actual.TotalPages);
		Assert.False(actual.HasPrevPage);
		Assert.True(actual.HasNextPage);
	}
}