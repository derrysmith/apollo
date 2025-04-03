using DerrySmith.Extensions.Domain.Features;
using WolverineFx = Wolverine;

namespace DerrySmith.Extensions.Domain.Wolverine.Features;

public interface IWolverineCommandHandler<T> : IFeatureCommandHandler<T>, WolverineFx.IWolverineHandler
	where T : IFeatureCommand;