using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace DerrySmith.Extensions.Core.HotChocolate;

public static class HotChocolateHostingExtensions
{
	public static void UseHotChocolate(
		this CoreHostingOptions options, Action<IRequestExecutorBuilder>? configure = null)
	{
		var builder = options.Builder.AddGraphQL();
		configure?.Invoke(builder);
	}

	public static void MapHotChocolate(this CoreHostingApplicationOptions options)
	{
		options.App.MapGraphQL();
	}
}