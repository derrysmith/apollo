using System.Reflection;

namespace Apollo.Entities;

public abstract record EntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	private static readonly EntityKeyFormatter _formatter;
	private static readonly EntityKeyGenerator _generator;
	
	protected EntityKey()
	{
		var entityKeyRawValue = _generator.Invoke();
		var entityKeyValue    = _formatter.Invoke(entityKeyRawValue);

		_value = entityKeyValue;
	}

	static EntityKey()
	{
		var entityKeyType = typeof(TEntityKey);
		var entityKeyAttr = entityKeyType.GetCustomAttribute<EntityKeyAttribute>();

		_formatter = entityKeyAttr?.Formatter ?? (value => value);
		_generator = entityKeyAttr?.Generator ?? (() => Guid.NewGuid().ToString("N").ToUpper());
	}

	private string _value;
	
	public static TEntityKey Parse(string value)
		=> new TEntityKey { _value = value };

	public sealed override string ToString()
		=> _value;
}