using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace DerrySmith.Extensions.Core;

public static class CoreHostingExtensions
{
	public static IHostApplicationBuilder AddCoreHosting(
		this IHostApplicationBuilder builder, Action<CoreHostingOptions>? configure = null)
	{
		var options = new CoreHostingOptions(builder);
		configure?.Invoke(options);

		return builder;
	}

	public static WebApplication UseCoreHosting(
		this WebApplication app, Action<CoreHostingApplicationOptions>? configure = null)
	{
		var options = new CoreHostingApplicationOptions(app);
		configure?.Invoke(options);

		return app;
	}
}