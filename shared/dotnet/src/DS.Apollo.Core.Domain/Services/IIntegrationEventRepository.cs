using DS.Apollo.Core.Domain.Messages;

namespace DS.Apollo.Core.Domain.Services;

public interface IIntegrationEventRepository
{
	IEnumerable<IIntegrationEvent> GetEvents();
	
	void Append<T>(T integrationEvent) where T : IIntegrationEvent;
	
	void RemoveEvents();
}