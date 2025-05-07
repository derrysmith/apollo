namespace DerrySmith.Extensions.Domain.Entities;

public interface IEntity;

public interface IEntity<out TEntityKey> : IEntity
{
	TEntityKey Id { get; }
}
