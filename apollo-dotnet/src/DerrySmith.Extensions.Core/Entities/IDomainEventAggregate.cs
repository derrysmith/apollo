namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TEvent"></typeparam>
public interface IDomainEventAggregate<in TEvent>
	where TEvent : IDomainEvent
{
	/// <summary></summary>
	/// <param name="domainEvent"></param>
	void Apply(TEvent domainEvent);
}