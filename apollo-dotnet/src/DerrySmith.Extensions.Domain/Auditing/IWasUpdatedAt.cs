namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IWasUpdatedAt
{
	/// <summary>
	/// 
	/// </summary>
	DateTimeOffset UpdatedAt { get; }
}