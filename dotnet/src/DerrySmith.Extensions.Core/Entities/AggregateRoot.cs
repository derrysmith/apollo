using DerrySmith.Extensions.Core.Messages;

namespace DerrySmith.Extensions.Core.Entities;

public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot
{
	private readonly List<IDomainEvent> _events = [];

	public IEnumerable<IDomainEvent> GetDomainEvents()
		=> _events.AsReadOnly();

	public void RemoveDomainEvents()
		=> _events.Clear();

	protected virtual void RaiseEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		this.ApplyEvent(domainEvent);
		this.StashEvent(domainEvent);
	}

	private void ApplyEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		// ReSharper disable once SuspiciousTypeConversion.Global
		if (this is IAggregateRoot<TEvent> aggregate)
			aggregate.Apply(domainEvent);
	}

	private void StashEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}