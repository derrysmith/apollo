namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TEntityKey"></typeparam>
public class EntityKeyException<TEntityKey> : Exception
{
	/// <summary></summary>
	/// <param name="value"></param>
	public EntityKeyException(string value)
		: this(value, $"Could not parse value '{value}' into {typeof(TEntityKey).Name} type.")
	{
		this.Value = value;
	}
	
	/// <summary></summary>
	/// <param name="value"></param>
	/// <param name="message"></param>
	public EntityKeyException(string value, string? message)
		: this(value, message, null)
	{
		this.Value = value;
	}
	
	/// <summary></summary>
	/// <param name="value"></param>
	/// <param name="message"></param>
	/// <param name="ex"></param>
	public EntityKeyException(string value, string? message, Exception? ex) : base(message, ex)
	{
		this.Value = value;
	}
	
	/// <summary></summary>
	public string Value { get; }
}