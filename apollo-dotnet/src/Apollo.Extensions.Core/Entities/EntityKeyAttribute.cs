namespace Apollo.Extensions.Core.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class EntityKeyAttribute : Attribute
{
	public string             Prefix    { get; init; } = string.Empty;
	public string             Suffix    { get; init; } = string.Empty;
	public EntityKeyValueType ValueType { get; init; } = EntityKeyValueType.Ulid;
}