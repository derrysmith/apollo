using Apollo.Contacts.Core.Entities.Models;

namespace Apollo.Tests.Contacts.Core;

public class UnitTest1
{
	[Fact]
	public void Test1()
	{
		var eventTypes = EventTypes.GetEventTypes();
		Assert.Equal(2, eventTypes.Count());
	}
}