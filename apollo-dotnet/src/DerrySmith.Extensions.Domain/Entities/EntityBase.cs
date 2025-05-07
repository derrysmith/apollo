namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntityKey"></typeparam>
public abstract class EntityBase<TEntityKey> : IEntity<TEntityKey>
{
	/// <inheritdoc />
	public TEntityKey Id { get; protected set; } = default!;
}