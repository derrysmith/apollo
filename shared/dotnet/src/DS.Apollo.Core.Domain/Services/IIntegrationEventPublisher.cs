using DS.Apollo.Core.Domain.Messages;

namespace DS.Apollo.Core.Domain.Services;

public interface IIntegrationEventPublisher
{
	Task PublishAsync<T>(T integrationEvent, CancellationToken ct = default)
		where T : IIntegrationEvent;
}