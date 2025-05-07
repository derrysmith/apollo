namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IWasCreatedAt
{
	/// <summary>
	/// 
	/// </summary>
	DateTimeOffset CreatedAt { get; }
}