namespace Apollo.Entities;

public interface IDomainEventHandler<in TDomainEvent>
	where TDomainEvent : IDomainEvent
{
	void Handle(TDomainEvent domainEvent);
}
