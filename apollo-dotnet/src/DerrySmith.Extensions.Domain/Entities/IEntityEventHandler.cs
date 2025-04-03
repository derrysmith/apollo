using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

public interface IEntityEventHandler<in TDomainEvent>
	where TDomainEvent : IDomainEvent
{
	void Apply(TDomainEvent domainEvent);
}
