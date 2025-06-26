using Wolverine;

namespace DerrySmith.Extensions.Core.Wolverine.Handlers;

public static class CoreWolverineHandlersExtensions
{
	public static void UseWolverine(this CoreHandlersOptions options, Action<WolverineOptions>? configure = null)
	{
		options.Services.AddWolverine(configure);
	}
}