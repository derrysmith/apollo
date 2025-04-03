using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

public interface IEntity;

public interface IEntity<out TEntityKey> : IEntity
{
	TEntityKey Id { get; }

	IEnumerable<IDomainEvent> GetDomainEvents();
	
	void RemoveDomainEvents();
}
