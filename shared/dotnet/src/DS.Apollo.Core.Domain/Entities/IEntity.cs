namespace DS.Apollo.Core.Domain.Entities;

public interface IEntity
{
	DateTimeOffset CreatedAt { get; }
	DateTimeOffset UpdatedAt { get; }
}

public interface IEntity<out TEntityKey> : IEntity
{
	TEntityKey Id { get; }
}