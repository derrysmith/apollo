using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

public interface IAggregateRoot
{
	IEnumerable<IDomainEvent> GetDomainEvents();
	
	void RemoveDomainEvents();
}
