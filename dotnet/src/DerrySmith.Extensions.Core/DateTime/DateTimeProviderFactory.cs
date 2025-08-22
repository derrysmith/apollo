namespace DerrySmith.Extensions.Core.DateTime;

public class DateTimeProviderFactory : IDateTimeProviderFactory
{
	public IDateTimeProvider Create() => new DateTimeProvider();
}