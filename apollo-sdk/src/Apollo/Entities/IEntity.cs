namespace Apollo.Entities;

/// <summary>
/// Marker interface for a domain entity.
/// </summary>
public interface IEntity;

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