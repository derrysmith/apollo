using DerrySmith.Extensions.Core.Messages;

namespace DerrySmith.Extensions.Core.Handlers;

/// <summary></summary>
/// <typeparam name="TEvent"></typeparam>
public interface IIntegrationEventHandler<TEvent> where TEvent : IIntegrationEvent;