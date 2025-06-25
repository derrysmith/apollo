namespace DerrySmith.Extensions.Core.DateTime;

/// <summary></summary>
public interface IDateTimeService
{
	/// <summary></summary>
	DateTimeOffset Now { get; }

	/// <summary></summary>
	DateTimeOffset UtcNow { get; }
}