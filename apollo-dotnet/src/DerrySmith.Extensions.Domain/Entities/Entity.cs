using DerrySmith.Extensions.Domain.Auditing;

namespace DerrySmith.Extensions.Domain.Entities;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TEntityKey"></typeparam>
public abstract class Entity<TEntityKey> : EntityBase<TEntityKey>, IAuditable
{
	/// <inheritdoc />
	public DateTimeOffset CreatedAt { get; protected set; }

	/// <inheritdoc />
	public string? CreatedBy { get; protected set; }

	/// <inheritdoc />
	public DateTimeOffset UpdatedAt { get; protected set; }

	/// <inheritdoc />
	public string? UpdatedBy { get; protected set; }
}