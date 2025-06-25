namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TAggRootKey"></typeparam>
public abstract class AggregateRoot<TAggRootKey> : Entity<TAggRootKey>, IAggregateRoot
{
	private readonly List<IDomainEvent> _events = [];

	/// <inheritdoc />
	public virtual IEnumerable<IDomainEvent> GetDomainEvents() => _events.AsReadOnly();

	/// <inheritdoc />
	public virtual void RemoveDomainEvents() => _events.Clear();

	/// <summary></summary>
	/// <param name="domainEvent"></param>
	/// <typeparam name="TEvent"></typeparam>
	protected virtual void RaiseDomainEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		this.ApplyDomainEvent(domainEvent);
		this.StashDomainEvent(domainEvent);
	}
	
	private void ApplyDomainEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		if (this is IDomainEventAggregate<TEvent> aggregate)
			aggregate.Apply(domainEvent);
	}
	
	private void StashDomainEvent<TEvent>(TEvent domainEvent)
		where TEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}