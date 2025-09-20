using Apollo.Extensions.Core.Messages;

namespace Apollo.Extensions.Core.Handlers;

public interface IDomainEventHandler<TEvent>
	where TEvent : IDomainEvent;

public interface IHandler<in TEvent> where TEvent : IDomainEvent
{
	// handles domain event, can result in zero or more other domain events
	Task<IEnumerable<IDomainEvent>> HandleAsync(TEvent domainEvent, CancellationToken ct = default);
}