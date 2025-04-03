using DerrySmith.Extensions.Domain.Handlers;
using DerrySmith.Extensions.Domain.Messages;
using WolverineFx = Wolverine;

namespace DerrySmith.Extensions.Domain.Wolverine.Handlers;

public interface IWolverineDomainEventHandler<T> : IDomainEventHandler<T>, WolverineFx.IWolverineHandler
	where T : IDomainEvent;