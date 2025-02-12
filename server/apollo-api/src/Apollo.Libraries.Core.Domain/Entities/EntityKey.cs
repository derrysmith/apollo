using System.Reflection;

namespace Apollo.Libraries.Core.Domain.Entities;

public abstract record EntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	private static Func<string, string>? _entityKeyFormatter;

	private string? _value;

	public sealed override string ToString()
		=> _value ?? base.ToString() ?? typeof(TEntityKey).Name;

	public static TEntityKey New()
	{
		var entityKeyRawValue = Ulid.NewUlid().ToString();
		var entityKeyValue    = EntityKey<TEntityKey>.GetEntityKeyValue(entityKeyRawValue);

		return EntityKey<TEntityKey>.Parse(entityKeyValue);
	}

	public static TEntityKey Parse(string value)
	{
		var entityKey = new TEntityKey();
		entityKey.SetValue(value);

		return entityKey;
	}

	private void SetValue(string value)
		=> _value = value;

	private static string GetEntityKeyValue(string entityKeyRawValue)
	{
		_entityKeyFormatter ??= EntityKey<TEntityKey>.GetEntityKeyValueFormatter(typeof(TEntityKey));

		return _entityKeyFormatter(entityKeyRawValue);
	}

	private static Func<string, string> GetEntityKeyValueFormatter(Type entityKeyType)
	{
		var attribute = entityKeyType.GetCustomAttribute<EntityKeyAttribute>();
		var prefix    = attribute?.Prefix ?? string.Empty;
		var suffix    = attribute?.Suffix ?? string.Empty;

		// create entity key formatter
		return rv => $"{prefix}{rv}{suffix}";
	}
}