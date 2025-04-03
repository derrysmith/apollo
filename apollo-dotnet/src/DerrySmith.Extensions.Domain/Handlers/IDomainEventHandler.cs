using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Handlers;

public interface IDomainEventHandler<TDomainEvent>
	where TDomainEvent : IDomainEvent;