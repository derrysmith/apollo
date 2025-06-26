using Wolverine;

namespace DerrySmith.Extensions.Core.Wolverine;

public static class WolverineHandlersExtensions
{
	public static void UseWolverine(this CoreHandlersOptions options, Action<WolverineOptions>? configure = null)
	{
		options.Services.AddWolverine(configure);
	}
}