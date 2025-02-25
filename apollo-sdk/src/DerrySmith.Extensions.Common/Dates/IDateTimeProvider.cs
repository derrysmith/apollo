namespace DerrySmith.Extensions.Common.Dates;

public interface IDateTimeProvider
{
	DateTimeOffset Now    { get; }
	DateTimeOffset UtcNow { get; }
}
