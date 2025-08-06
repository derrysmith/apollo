namespace DerrySmith.Apollo.Extensions.Core.Entities;

internal record EntityKeyMetadata
{
	public string FileName  { get; }
	public string TypeName  { get; }
	public string Namespace { get; }

	public string Prefix { get; }
	public string Suffix { get; }

	public EntityKeyMetadata(string fileName, string typeName, string @namespace, string prefix, string suffix)
	{
		this.FileName  = fileName;
		this.TypeName  = typeName;
		this.Namespace = @namespace;
		this.Prefix    = prefix;
		this.Suffix    = suffix;
	}
}