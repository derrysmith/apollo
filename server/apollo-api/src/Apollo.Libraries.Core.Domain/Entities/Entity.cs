using Apollo.Libraries.Core.Domain.Messages;

namespace Apollo.Libraries.Core.Domain.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	private readonly List<IDomainEvent> _events = [];

	public TEntityKey Id { get; protected set; } = default!;

	public IEnumerable<IDomainEvent> GetDomainEvents()
		=> _events.AsReadOnly();

	public void RemoveDomainEvents()
		=> _events.Clear();

	protected virtual void RaiseDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		this.ApplyDomainEvent(domainEvent);
		this.StashDomainEvent(domainEvent);
	}

	private void ApplyDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		var handler = this as IAggregateRootEventHandler<TDomainEvent>;
		handler?.Handle(domainEvent);
	}

	private void StashDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}
