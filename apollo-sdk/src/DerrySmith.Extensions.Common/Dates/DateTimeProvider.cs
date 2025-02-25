namespace DerrySmith.Extensions.Common.Dates;

public sealed class DateTimeProvider : IDateTimeProvider
{
	public DateTimeOffset Now    => DateTimeOffset.Now;
	public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
