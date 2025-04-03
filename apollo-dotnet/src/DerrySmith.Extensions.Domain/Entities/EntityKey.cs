using System.Reflection;

namespace DerrySmith.Extensions.Domain.Entities;

public abstract record EntityKey<TEntityKey>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	// ReSharper disable once StaticMemberInGenericType
	private static readonly EntityKeyAttribute Attribute;

	static EntityKey()
	{
		Attribute = EntityKey<TEntityKey>.GetEntityKeyAttribute() ?? new EntityKeyAttribute();
	}

	protected string InnerValue { get; init; } = default!;

	public static TEntityKey New()
	{
		var entityKeyRawValue = Attribute.Generator();
		var entityKeyValue    = Attribute.Formatter(entityKeyRawValue);
		var entityKey         = EntityKey<TEntityKey>.Parse(entityKeyValue);

		return entityKey;
	}

	public static TEntityKey Parse(string entityKeyValue)
		=> new TEntityKey { InnerValue = entityKeyValue };

	public bool IsEmpty()
		=> string.IsNullOrEmpty(this.InnerValue);

	public sealed override string ToString()
		=> this.InnerValue;

	private static EntityKeyAttribute? GetEntityKeyAttribute()
	{
		var entityKeyType = typeof(TEntityKey);
		var entityKeyAttr = entityKeyType.GetCustomAttribute<EntityKeyAttribute>();

		return entityKeyAttr;
	}
}
