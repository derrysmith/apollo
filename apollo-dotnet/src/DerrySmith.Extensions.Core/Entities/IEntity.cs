namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
public interface IEntity;

/// <summary></summary>
/// <typeparam name="TEntityKey"></typeparam>
public interface IEntity<out TEntityKey> : IEntity
{
	/// <summary></summary>
	TEntityKey Id { get; }
}