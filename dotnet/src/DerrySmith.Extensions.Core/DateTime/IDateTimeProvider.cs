namespace DerrySmith.Extensions.Core.DateTime;

public interface IDateTimeProvider
{
	DateTimeOffset Now    { get; }
	DateTimeOffset UtcNow { get; }
}