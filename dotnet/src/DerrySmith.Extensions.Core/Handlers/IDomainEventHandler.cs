using DerrySmith.Extensions.Core.Messages;

namespace DerrySmith.Extensions.Core.Handlers;

public interface IDomainEventHandler<TEvent>
	where TEvent : IDomainEvent;