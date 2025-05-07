namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IWasDeletedAt
{
	/// <summary>
	/// 
	/// </summary>
	DateTimeOffset? DeletedAt { get; }
}