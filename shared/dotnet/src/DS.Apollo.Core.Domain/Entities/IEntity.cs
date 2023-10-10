namespace DS.Apollo.Core.Domain.Entities;

public interface IEntity<out TEntityKey>
	where TEntityKey : IEntityKey
{
	TEntityKey Id { get; }
}