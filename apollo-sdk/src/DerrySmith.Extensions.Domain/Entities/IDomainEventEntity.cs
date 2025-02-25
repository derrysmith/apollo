namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// Represents a domain entity that uses the specified domain event type to update its own state.
/// </summary>
/// 
/// <typeparam name="TDomainEvent">
/// The type of the domain event.
/// </typeparam>
public interface IDomainEventEntity<in TDomainEvent>
	where TDomainEvent : IDomainEvent
{
	/// <summary>
	/// Applies the given domain event against the entity's internal state.
	/// </summary>
	/// 
	/// <param name="domainEvent">
	/// The domain event to apply.
	/// </param>
	void Apply(TDomainEvent domainEvent);
}
