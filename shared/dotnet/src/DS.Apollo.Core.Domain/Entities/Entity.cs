namespace DS.Apollo.Core.Domain.Entities;

public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
	where TEntityKey : IEntityKey
{
	public TEntityKey Id { get; protected set; }
}