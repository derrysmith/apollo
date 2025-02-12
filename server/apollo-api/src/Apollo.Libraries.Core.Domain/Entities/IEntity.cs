using Apollo.Libraries.Core.Domain.Messages;

namespace Apollo.Libraries.Core.Domain.Entities;

public interface IEntity
{
	IEnumerable<IDomainEvent> GetDomainEvents();

	void RemoveDomainEvents();
}

public interface IEntity<out TEntityKey> : IEntity
{
	TEntityKey Id { get; }
}
