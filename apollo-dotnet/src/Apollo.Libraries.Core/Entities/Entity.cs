namespace Apollo.Libraries.Core.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
{
	public TEntityKey Id { get; protected set; } = default!;
}