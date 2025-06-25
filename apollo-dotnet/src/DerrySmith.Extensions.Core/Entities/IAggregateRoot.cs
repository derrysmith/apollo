namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
public interface IAggregateRoot
{
	/// <summary></summary>
	/// <returns></returns>
	IEnumerable<IDomainEvent> GetDomainEvents();

	/// <summary></summary>
	void RemoveDomainEvents();
}