using System.Reflection;

namespace Apollo.Extensions.Core.Entities;

public abstract record EntityKey<TEntityKey> : IEntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	private static readonly EntityKeyAttribute Attribute;
	private static readonly Func<string>       Generator;

	private string _value = string.Empty;

	static EntityKey()
	{
		// get customer attribute for this specific entity key type
		Attribute = typeof(TEntityKey).GetCustomAttribute<EntityKeyAttribute>() ?? new EntityKeyAttribute();

		// generator - create new entity key value
		Generator = () =>
		{
			return Attribute.ValueType switch
			{
				EntityKeyValueType.Guid => Guid.NewGuid().ToString("N"),
				EntityKeyValueType.Ulid => Ulid.NewUlid().ToString(),
				_                       => throw new InvalidOperationException(),
			};
		};
	}

	public static TEntityKey New()
	{
		return Create(Generator());
	}

	public static TEntityKey Parse(string value)
	{
		if (TryParse(value, out var entityKey))
			return entityKey;

		var error = $"Cannot parse '{value}' into type {typeof(TEntityKey).Name}.";
		throw new ArgumentException(error, nameof(value));
	}

	public static bool TryParse(string value, out TEntityKey entityKey)
	{
		var parseResult = false;

		// extract entity key value (as string) from value
		var entityKeyValueString = EntityKeyExtensions.ExtractEntityKeyValue(value, Attribute.Prefix, Attribute.Suffix);

		switch (Attribute.ValueType)
		{
			case EntityKeyValueType.Guid:
				parseResult    = Guid.TryParse(entityKeyValueString, out var guid);
				entityKey = parseResult ? Create(guid.ToString("N")) : null!;

				break;
			case EntityKeyValueType.Ulid:
				parseResult = Ulid.TryParse(entityKeyValueString, out var ulid);
				entityKey   = parseResult ? Create(ulid.ToString()) : null!;

				break;
			default:
				entityKey = null!;
				break;
		}

		return parseResult;
	}

	public sealed override string ToString()
	{
		return $"{Attribute.Prefix}{_value}{Attribute.Suffix}";
	}

	private static TEntityKey Create(string value)
	{
		return new TEntityKey { _value = value };
	}
}

// public abstract record EntityKey<TEntityKey> : EntityKey<TEntityKey, Ulid>
// 	where TEntityKey : EntityKey<TEntityKey>, new();
//
// public abstract record EntityKey<TEntityKey, TEntityKeyValue> : IEntityKey<TEntityKey, TEntityKeyValue>
// 	where TEntityKey : EntityKey<TEntityKey, TEntityKeyValue>, new()
// {
// 	private static readonly string Prefix;
// 	private static readonly string Suffix;
//
// 	private static readonly EntityKeyAttribute                       Attribute;
// 	private static readonly EntityKeyValueGenerator<TEntityKeyValue> Generator;
// 	private static readonly EntityKeyValueFormatter<TEntityKeyValue> Formatter;
// 	private static readonly EntityKeyValueParser<TEntityKeyValue>    Parser;
//
// 	public static TEntityKey Empty => New(default!);
//
// 	public TEntityKeyValue Value { get; private init; } = default!;
//
// 	static EntityKey()
// 	{
// 		Attribute = typeof(TEntityKey).GetCustomAttribute<EntityKeyAttribute>() ?? new EntityKeyAttribute();
//
// 		Prefix = Attribute.Prefix;
// 		Suffix = Attribute.Suffix;
//
// 		// Generator = () =>
// 		// {
// 		// 	return typeof(TEntityKeyValue) switch
// 		// 	{
// 		// 		var type when type == typeof(int) => (TEntityKeyValue)0,
// 		// 		var type when type == typeof(Guid) => (TEntityKeyValue)Guid.NewGuid(),
// 		// 	};
// 		// };
// 		
// 		Generator = Generators[typeof(TEntityKeyValue)];
//
// 		Formatter = entityKeyValue =>
// 		{
// 			return entityKeyValue switch
// 			{
// 				Guid g => g.ToString("N"),
// 				_      => entityKeyValue?.ToString() ?? string.Empty,
// 			};
// 		};
//
// 		Parser = value =>
// 		{
// 			var entityKeyValueType = typeof(TEntityKeyValue);
// 			
// 			// parse as int
// 			if (entityKeyValueType == typeof(int))
// 				return int.Parse(value);
// 			
// 			// parse as long
// 			if (entityKeyValueType == typeof(long))
// 				return long.Parse(value);
// 			
// 			// parse as guid
// 			if (entityKeyValueType == typeof(Guid))
// 				return Guid.Parse(value);
// 		};
// 	}
//
// 	public static TEntityKey New()
// 	{
// 		return New(Generator());
// 	}
//
// 	public static TEntityKey New(TEntityKeyValue value)
// 	{
// 		return new TEntityKey { Value = value };
// 	}
//
// 	public static TEntityKey Parse(string value)
// 	{
// 		if (TryParse(value, out var entityKey))
// 			return entityKey;
//
// 		var error = $"Cannot parse '{value}' into type {typeof(TEntityKey).Name}.";
// 		throw new ArgumentException(error, nameof(value));
// 	}
//
// 	public static bool TryParse(string value, out TEntityKey entityKey)
// 	{
// 		// extract entity key value (as string) from value
// 		var entityKeyValueString = value;
//
// 		if (Parser(entityKeyValueString, out var entityKeyValue))
// 		{
// 			entityKey = New(entityKeyValue);
// 			return true;
// 		}
//
// 		entityKey = null!;
// 		return false;
// 	}
//
// 	public sealed override string ToString()
// 	{
// 		return $"{Prefix}{Formatter(this.Value)}{Suffix}";
// 	}
// }