namespace DerrySmith.Extensions.Domain.Auditing;

/// <summary>
/// 
/// </summary>
public interface IWasDeletedBy
{
	/// <summary>
	/// 
	/// </summary>
	string? DeletedBy { get; }
}