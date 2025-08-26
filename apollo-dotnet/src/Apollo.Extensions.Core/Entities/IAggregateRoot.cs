using Apollo.Extensions.Core.Messages;

namespace Apollo.Extensions.Core.Entities;

public interface IAggregateRoot
{
	IEnumerable<IDomainEvent> GetDomainEvents();

	void RemoveDomainEvents();
}

public interface IAggregateRoot<in TEvent>
	where TEvent : IDomainEvent
{
	void Apply(TEvent domainEvent);
}