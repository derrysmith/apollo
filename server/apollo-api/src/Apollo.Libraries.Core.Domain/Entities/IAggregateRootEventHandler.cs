using Apollo.Libraries.Core.Domain.Messages;

namespace Apollo.Libraries.Core.Domain.Entities;

public interface IAggregateRootEventHandler<in TDomainEvent>
	where TDomainEvent : IDomainEvent
{
	void Handle(TDomainEvent domainEvent);
}
