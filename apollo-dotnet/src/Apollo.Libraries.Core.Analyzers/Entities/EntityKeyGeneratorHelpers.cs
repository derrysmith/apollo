namespace Apollo.Libraries.Core.Entities;

internal static class EntityKeyGeneratorHelpers
{
	public const string EntityKeyAttributeFullName = "Apollo.Libraries.Core.Entities.EntityKeyAttribute";
	public const string EntityKeyAttributeTypeName = "EntityKeyAttribute";

	public const string EntityKeyAttributeSourceCode = @"
namespace Apollo.Libraries.Core.Entities
{
	[System.AttributeUsage(System.AttributeTargets.Struct)]
	public sealed class EntityKeyAttribute : System.Attribute
	{
		public string Prefix { get; set; } = string.Empty;
		public string Suffix { get; set; } = string.Empty;
	}
}
";

	public const string EntityKeyInterfaceSourceCode = @"
namespace Apollo.Libraries.Core.Entities
{
	public interface IEntityKey<T> where T : struct, IEntityKey<T>
	{
		static abstract T New();

		static abstract T Parse(string value);

		static abstract bool TryParse(string value, out T entityKey);
	}
}
";
}