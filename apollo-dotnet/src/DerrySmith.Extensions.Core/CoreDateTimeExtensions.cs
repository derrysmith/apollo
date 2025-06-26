using DerrySmith.Extensions.Core.DateTime;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace DerrySmith.Extensions.Core;

public static class CoreDateTimeExtensions
{
	public static IServiceCollection AddCoreDateTime(
		this IServiceCollection services, Action<CoreDateTimeOptions>? configure = null)
	{
		var options = new CoreDateTimeOptions(services);
		configure?.Invoke(options);
		
		// register IDateTimeService (if not already registered)
		services.TryAddScoped<IDateTimeService, DateTimeService>();

		return services;
	}
}