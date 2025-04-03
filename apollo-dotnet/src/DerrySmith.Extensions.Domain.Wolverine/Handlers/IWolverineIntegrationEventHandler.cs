using DerrySmith.Extensions.Domain.Handlers;
using DerrySmith.Extensions.Domain.Messages;
using WolverineFx = Wolverine;

namespace DerrySmith.Extensions.Domain.Wolverine.Handlers;

public interface IWolverineIntegrationEventHandler<T> : IIntegrationEventHandler<T>, WolverineFx.IWolverineHandler
	where T : IIntegrationEvent;
