using System.Diagnostics.CodeAnalysis;

namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TEntityKey"></typeparam>
public abstract record EntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	/// <summary></summary>
	public static readonly TEntityKey Empty = EntityKey<TEntityKey>.NewEntityKey(Ulid.Empty);
	
	// ReSharper disable once InconsistentNaming
	// ReSharper disable once StaticMemberInGenericType
	private static readonly EntityKeyAttribute _attribute;

	private Ulid InnerValue { get; init; } = Ulid.Empty;

	static EntityKey()
	{
		_attribute = typeof(TEntityKey).GetEntityKeyAttribute();
	}

	/// <summary></summary>
	/// <returns></returns>
	public static TEntityKey New()
	{
		return NewEntityKey(_attribute.ValueGenerator());
	}

	
	/// <summary></summary>
	/// <param name="value"></param>
	/// <returns></returns>
	/// <exception cref="EntityKeyException{TEntityKey}"></exception>
	public static TEntityKey Parse(string value)
	{
		if (TryParse(value, out var entityKey))
			return entityKey;

		throw new EntityKeyException<TEntityKey>(value);
	}

	/// <summary></summary>
	/// <param name="value"></param>
	/// <returns></returns>
	/// <exception cref="EntityKeyException{TEntityKey}"></exception>
	public static TEntityKey Parse(Guid value)
	{
		if (TryParse(value, out var entityKey))
			return entityKey;

		throw new EntityKeyException<TEntityKey>(value.ToString("D"));
	}

	/// <summary></summary>
	/// <param name="value"></param>
	/// <param name="entityKey"></param>
	/// <returns></returns>
	public static bool TryParse(string value, [NotNullWhen(true)] out TEntityKey? entityKey)
	{
		var entityKeyValue = ExtractEntityKeyValue(value);

		if (Ulid.TryParse(entityKeyValue, out var ulid))
		{
			entityKey = NewEntityKey(ulid);
			return true;
		}

		if (Guid.TryParse(entityKeyValue, out var guid))
		{
			entityKey = NewEntityKey(new Ulid(guid));
			return true;
		}

		entityKey = null;
		return false;
	}

	/// <summary></summary>
	/// <param name="value"></param>
	/// <param name="entityKey"></param>
	/// <returns></returns>
	public static bool TryParse(Guid value, [NotNullWhen(true)] out TEntityKey? entityKey)
	{
		entityKey = NewEntityKey(new Ulid(value));
		return true;
	}

	/// <inheritdoc />
	public sealed override string ToString()
	{
		return _attribute.ValueFormatter(this.InnerValue);
	}
	
	/// <summary></summary>
	/// <returns></returns>
	public Guid ToGuid()
	{
		return this.InnerValue.ToGuid();
	}

	private static TEntityKey NewEntityKey(Ulid value)
	{
		return new TEntityKey { InnerValue = value };
	}

	private static string ExtractEntityKeyValue(string value)
	{
		return value[_attribute.Prefix.Length..];
	}
}