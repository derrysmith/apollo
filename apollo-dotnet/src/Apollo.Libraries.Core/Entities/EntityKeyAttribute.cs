namespace Apollo.Libraries.Core.Entities;

[System.AttributeUsage(System.AttributeTargets.Struct)]
public sealed class EntityKeyAttribute : System.Attribute
{
	public string Prefix { get; set; } = string.Empty;
	public string Suffix { get; set; } = string.Empty;
}