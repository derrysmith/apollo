namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class EntityKeyAttribute : Attribute
{
	/// <summary></summary>
	public string Prefix { get; init; } = string.Empty;

	/// <summary></summary>
	internal Func<Ulid> ValueGenerator { get; }

	/// <summary></summary>
	internal Func<Ulid, string> ValueFormatter { get; }

	/// <summary></summary>
	public EntityKeyAttribute()
	{
		// how do we generate a new entity key value
		this.ValueGenerator = Ulid.NewUlid;

		// how do we format the entity key value
		this.ValueFormatter = id => string.IsNullOrEmpty(this.Prefix)
			? id.ToString()
			: $"{this.Prefix}{id}";
	}
}