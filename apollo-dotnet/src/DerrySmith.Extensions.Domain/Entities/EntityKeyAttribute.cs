namespace DerrySmith.Extensions.Domain.Entities;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class EntityKeyAttribute : Attribute
{
	public EntityKeyAttribute()
	{
		this.Format    = "{0}";
		this.Formatter = raw => string.Format(this.Format, raw);
		this.Generator = () => Ulid.NewUlid().ToString();
	}
	
	public string               Format    { get; init; }
	public Func<string, string> Formatter { get; }
	public Func<string>         Generator { get; }
}
