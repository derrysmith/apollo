namespace DerrySmith.Core.Common.Dates;

public interface IDateTimeProvider
{
	DateTimeOffset Now    { get; }
	DateTimeOffset UtcNow { get; }
}
