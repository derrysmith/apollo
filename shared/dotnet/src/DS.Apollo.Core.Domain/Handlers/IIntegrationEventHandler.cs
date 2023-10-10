using DS.Apollo.Core.Domain.Messages;

namespace DS.Apollo.Core.Domain.Handlers;

public interface IIntegrationEventHandler<in T>
	where T : IIntegrationEvent
{
	Task HandleAsync(T integrationEvent, CancellationToken ct = default);
}