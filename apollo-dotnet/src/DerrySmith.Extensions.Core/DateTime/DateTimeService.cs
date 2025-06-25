namespace DerrySmith.Extensions.Core.DateTime;

/// <summary></summary>
public sealed class DateTimeService : IDateTimeService
{
	/// <inheritdoc />
	public DateTimeOffset Now => DateTimeOffset.Now;

	/// <inheritdoc />
	public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}