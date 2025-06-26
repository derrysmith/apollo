using Microsoft.Extensions.Hosting;

namespace DerrySmith.Extensions.Core;

public class CoreHostingOptions(IHostApplicationBuilder builder)
{
	public IHostApplicationBuilder Builder { get; } = builder;
}