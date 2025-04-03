using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Handlers;

public interface IIntegrationEventHandler<TIntegrationEvent>
	where TIntegrationEvent : IIntegrationEvent;
