using Apollo.Extensions.Core.Messages;

namespace Apollo.Extensions.Core.Handlers;

public interface IIntegrationEventHandler<TEvent>
	where TEvent : IIntegrationEvent;