namespace Apollo.Libraries.Core.Entities;

internal class EntityKey
{
	public string TypeName      { get; set; } // UserId
	public string TypeNamespace { get; set; } // My.Namespace

	public string Prefix { get; set; }
	public string Suffix { get; set; }

	public string FullName => $"{this.TypeNamespace}.{this.TypeName}";
	public string FileName => $"{this.FullName}.g.cs";

	public EntityKey(string typeNamespace, string typeName, string prefix, string suffix)
	{
		this.TypeNamespace = typeNamespace;
		this.TypeName      = typeName;
		this.Prefix        = prefix;
		this.Suffix        = suffix;
	}
}