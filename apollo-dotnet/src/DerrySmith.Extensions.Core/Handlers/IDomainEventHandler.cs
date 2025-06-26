using DerrySmith.Extensions.Core.Entities;

namespace DerrySmith.Extensions.Core.Handlers;

/// <summary></summary>
/// <typeparam name="TEvent"></typeparam>
public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent;