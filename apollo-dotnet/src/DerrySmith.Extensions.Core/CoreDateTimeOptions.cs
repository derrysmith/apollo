using DerrySmith.Extensions.Core.DateTime;
using Microsoft.Extensions.DependencyInjection;

namespace DerrySmith.Extensions.Core;

public class CoreDateTimeOptions(IServiceCollection services)
{
	public void UseService<TDateTimeService>()
		where TDateTimeService : class, IDateTimeService
	{
		services.AddScoped<IDateTimeService, TDateTimeService>();
	}
}