namespace Apollo.Entities;

/// <inheritdoc />
public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	private readonly List<IDomainEvent> _events = [];
	
	/// <inheritdoc />
	public TEntityKey Id { get; protected set; } = default!;

	protected virtual void RaiseDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		this.ApplyDomainEvent(domainEvent);
		this.StashDomainEvent(domainEvent);
	}

	private void ApplyDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		var handler = this as IDomainEventHandler<TDomainEvent>;
		handler?.Handle(domainEvent);
	}

	private void StashDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}
