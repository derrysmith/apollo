using DerrySmith.Extensions.Domain.Features;
using WolverineFx = Wolverine;

namespace DerrySmith.Extensions.Domain.Wolverine.Features;

public interface IWolverineRequestHandler<TReq, T> : IFeatureRequestHandler<TReq, T>, WolverineFx.IWolverineHandler
	where TReq : IFeatureRequest<T>;
