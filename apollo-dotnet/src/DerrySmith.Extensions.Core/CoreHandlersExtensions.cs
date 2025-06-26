using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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