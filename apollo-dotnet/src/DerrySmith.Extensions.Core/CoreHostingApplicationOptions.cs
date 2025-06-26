using Microsoft.AspNetCore.Builder;

namespace DerrySmith.Extensions.Core;

public class CoreHostingApplicationOptions(WebApplication app)
{
	public WebApplication App { get; } = app;
}