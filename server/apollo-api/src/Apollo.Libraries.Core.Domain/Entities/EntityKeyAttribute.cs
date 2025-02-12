namespace Apollo.Libraries.Core.Domain.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class EntityKeyAttribute : Attribute
{
	public string? Prefix { get; init; }
	public string? Suffix { get; init; }
}
