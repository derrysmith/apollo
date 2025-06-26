using Microsoft.Extensions.DependencyInjection;

namespace DerrySmith.Extensions.Core;

public class CoreHandlersOptions(IServiceCollection services)
{
	public IServiceCollection Services { get; } = services;
}