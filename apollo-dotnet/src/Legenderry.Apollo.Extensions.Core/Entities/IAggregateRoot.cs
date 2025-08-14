using Legenderry.Apollo.Extensions.Core.Messages;

namespace Legenderry.Apollo.Extensions.Core.Entities;

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