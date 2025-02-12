using Apollo.Libraries.Core.Domain.Messages;

namespace Apollo.Libraries.Core.Domain.Handlers;

public interface IDomainEventHandler<in TDomainEvent> : MediatR.INotificationHandler<TDomainEvent>
	where TDomainEvent : IDomainEvent;
