namespace DerrySmith.Extensions.Core.Entities;

/// <summary>Marker interface for local domain events.</summary>
/// <remarks>
/// Domain events should not be serialized.
/// Communicate with services outside of the bounded context by
/// transforming domain events into integration events.
/// </remarks>
public interface IDomainEvent;