namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IWasUpdatedBy
{
	/// <summary>
	/// 
	/// </summary>
	string? UpdatedBy { get; }
}