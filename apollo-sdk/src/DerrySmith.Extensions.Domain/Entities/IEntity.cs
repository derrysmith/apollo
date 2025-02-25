namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// Represents a domain entity.
/// </summary>
public interface IEntity
{
	/// <summary>
	/// Get the current internal collection of pending domain events.
	/// </summary>
	/// 
	/// <returns>
	/// A collection of pending domain events.
	/// </returns>
	IEnumerable<IDomainEvent> GetDomainEvents();

	/// <summary>
	/// Removes all pending domain events from the entity's internal collection.
	/// </summary>
	void RemoveDomainEvents();
}

/// <summary>
/// Represents a domain entity with a single unique identifier.
/// </summary>
/// 
/// <typeparam name="TEntityKey">
/// The type of the entity's unique identifier.
/// </typeparam>
public interface IEntity<out TEntityKey> : IEntity
{
	/// <summary>
	/// The entity's unique identifier.
	/// </summary>
	TEntityKey Id { get; }
}
