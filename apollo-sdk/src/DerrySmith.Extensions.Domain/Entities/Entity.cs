namespace DerrySmith.Extensions.Domain.Entities;

/// <inheritdoc />
public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	private readonly List<IDomainEvent> _events = [];
	
	/// <inheritdoc />
	public TEntityKey Id { get; protected set; } = default!;

	/// <inheritdoc />
	public IEnumerable<IDomainEvent> GetDomainEvents()
		=> _events.AsReadOnly();

	/// <inheritdoc />
	public void RemoveDomainEvents()
		=> _events.Clear();

	/// <summary>
	/// Raises the specified domain event by appending it to its internal collection of events.
	/// </summary>
	/// 
	/// <remarks>
	/// Domain events within this entity's collection should be published by a
	/// unit-of-work context, not by then entity itself, and then handled in-process.
	/// </remarks>
	/// 
	/// <param name="domainEvent">
	/// The domain event to raise.
	/// </param>
	/// 
	/// <typeparam name="TDomainEvent">
	/// The type of the domain event to raise.
	/// </typeparam>
	protected virtual void RaiseDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		this.ApplyDomainEvent(domainEvent);
		this.StashDomainEvent(domainEvent);
	}

	private void ApplyDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		var entity = this as IDomainEventEntity<TDomainEvent>;
		entity?.Apply(domainEvent);
	}

	private void StashDomainEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}