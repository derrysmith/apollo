using Microsoft.Extensions.DependencyInjection;

namespace DerrySmith.Extensions.Core;

public static class CoreHandlersExtensions
{
	public static IServiceCollection AddCoreHandlers(
		this IServiceCollection services, Action<CoreHandlersOptions>? configure = null)
	{
		var options = new CoreHandlersOptions(services);
		configure?.Invoke(options);

		return services;
	}
}