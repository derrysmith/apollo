using DerrySmith.Extensions.Core.Messages;

namespace DerrySmith.Extensions.Core.Handlers;

public interface IIntegrationEventHandler<TEvent>
	where TEvent : IIntegrationEvent;