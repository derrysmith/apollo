using Apollo.Extensions.Core.Messages;

namespace Apollo.Extensions.Core.Handlers;

public interface IDomainEventHandler<TEvent>
	where TEvent : IDomainEvent;