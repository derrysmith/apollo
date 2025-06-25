namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TEntityKey"></typeparam>
public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	/// <inheritdoc />
	public virtual TEntityKey Id { get; protected set; } = default!;
}