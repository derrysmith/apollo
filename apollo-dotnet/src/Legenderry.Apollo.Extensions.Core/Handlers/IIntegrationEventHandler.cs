using Legenderry.Apollo.Extensions.Core.Messages;

namespace Legenderry.Apollo.Extensions.Core.Handlers;

public interface IIntegrationEventHandler<TEvent>
	where TEvent : IIntegrationEvent;