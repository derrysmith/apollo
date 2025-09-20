namespace Apollo.Libraries.Core.DateTime;

public class DateTimeProviderFactory : IDateTimeProviderFactory
{
	public IDateTimeProvider Create() => new DateTimeProvider();
}