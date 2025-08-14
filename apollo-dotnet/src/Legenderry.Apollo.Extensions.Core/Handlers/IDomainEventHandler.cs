using Legenderry.Apollo.Extensions.Core.Messages;

namespace Legenderry.Apollo.Extensions.Core.Handlers;

public interface IDomainEventHandler<TEvent>
	where TEvent : IDomainEvent;