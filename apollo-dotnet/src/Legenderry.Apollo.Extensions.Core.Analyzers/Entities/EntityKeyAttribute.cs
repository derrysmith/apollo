namespace Legenderry.Apollo.Extensions.Core.Entities;

/// <summary>
/// 
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Struct)]
public sealed class EntityKeyAttribute : System.Attribute
{
	/// <summary>
	/// 
	/// </summary>
	public string Prefix { get; set; } = string.Empty;
	
	/// <summary>
	/// 
	/// </summary>
	public string Suffix { get; set; } = string.Empty;
}