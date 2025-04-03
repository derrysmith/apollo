using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	private readonly List<IDomainEvent> _events = [];

	public TEntityKey Id { get; protected set; } = default!;

	public IEnumerable<IDomainEvent> GetDomainEvents()
		=> _events.AsReadOnly();

	public void RemoveDomainEvents()
		=> _events.Clear();

	protected virtual void RaiseEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		this.ApplyEvent(domainEvent);
		this.StashEvent(domainEvent);
	}

	private void ApplyEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		// ReSharper disable once SuspiciousTypeConversion.Global
		if (this is IEntityEventHandler<TDomainEvent> handler)
			handler.Apply(domainEvent);
	}

	private void StashEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}
