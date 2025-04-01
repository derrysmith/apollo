using System.Reflection;

namespace DerrySmith.Extensions.Domain.Entities;

public abstract record EntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	private static readonly EntityKeyAttribute _attribute;

	static EntityKey()
	{
		_attribute = EntityKey<TEntityKey>.GetEntityKeyAttribute() ?? new EntityKeyAttribute();
	}

	private string _value;

	protected EntityKey() : this(string.Empty) { }

	private EntityKey(string value)
	{
		_value = string.IsNullOrEmpty(value) ? string.Empty : value;
	}

	public static TEntityKey New()
	{
		var entityKeyRawValue = _attribute.Generator.Invoke();
		var entityKeyValue    = _attribute.Formatter.Invoke(entityKeyRawValue);
		var entityKey         = EntityKey<TEntityKey>.Parse(entityKeyValue);

		return entityKey;
	}

	public static TEntityKey Parse(string value)
	{
		var entityKey = new TEntityKey();
		entityKey.SetValue(value);

		return entityKey;
	}

	public bool IsEmpty() => string.IsNullOrEmpty(_value);

	public sealed override string ToString() => _value ?? base.ToString() ?? typeof(TEntityKey).Name;

	private static EntityKeyAttribute? GetEntityKeyAttribute()
	{
		var entityKeyType = typeof(TEntityKey);
		var entityKeyAttr = entityKeyType.GetCustomAttribute<EntityKeyAttribute>();

		return entityKeyAttr;
		
	}

	private void SetValue(string value)
		=> _value = value;
}
