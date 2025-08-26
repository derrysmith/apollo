namespace Apollo.Extensions.Core.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	public TEntityKey Id { get; protected set; } = default!;
}