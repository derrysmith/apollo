namespace DS.Apollo.Core.Domain.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
	where TEntityKey : IEntityKey
{
	public virtual TEntityKey Id { get; protected set; } = default!;

	public virtual DateTimeOffset CreatedAt { get; protected set; } = default!;
	public virtual DateTimeOffset UpdatedAt { get; protected set; } = default!;
}