using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TAggRootKey"></typeparam>
public abstract class AggregateRootBase<TAggRootKey> : EntityBase<TAggRootKey>, IAggregateRoot
{
	private readonly List<IDomainEvent> _events = [];

	/// <inheritdoc />
	public IEnumerable<IDomainEvent> GetDomainEvents() => _events.AsReadOnly();

	/// <inheritdoc />
	public void RemoveDomainEvents() => _events.Clear();

	/// <summary>
	/// 
	/// </summary>
	/// <param name="domainEvent"></param>
	/// <typeparam name="TDomainEvent"></typeparam>
	protected void RaiseEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		this.ApplyEvent(domainEvent);
		this.StashEvent(domainEvent);
	}

	private void ApplyEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		// ReSharper disable once SuspiciousTypeConversion.Global
		if (this is IAggregateRootConsumer<TDomainEvent> consumer)
			consumer.Consume(domainEvent);
	}

	private void StashEvent<TDomainEvent>(TDomainEvent domainEvent)
		where TDomainEvent : IDomainEvent
	{
		_events.Add(domainEvent);
	}
}