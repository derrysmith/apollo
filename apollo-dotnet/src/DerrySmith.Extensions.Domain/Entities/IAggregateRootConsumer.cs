using DerrySmith.Extensions.Domain.Messages;

namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TDomainEvent"></typeparam>
public interface IAggregateRootConsumer<in TDomainEvent>
	where TDomainEvent : IDomainEvent
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="domainEvent"></param>
	void Consume(TDomainEvent domainEvent);
}
