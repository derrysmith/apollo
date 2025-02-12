namespace Apollo.Entities;

/// <summary>
/// Specifies that the target type is a strongly typed identifier of a domain entity.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class EntityKeyAttribute : Attribute
{
	public string Format { get; init; } = "{0}";

	public EntityKeyFormatter Formatter
		=> value => string.Format(this.Format, value);

	public EntityKeyGenerator Generator
		=> this.GetGenerator(this.GeneratorType);

	public EntityKeyGeneratorType GeneratorType { get; init; } = EntityKeyGeneratorType.SequentialGuid;

	private EntityKeyGenerator GetGenerator(EntityKeyGeneratorType entityKeyGeneratorType)
	{
		return entityKeyGeneratorType switch
		{
			EntityKeyGeneratorType.StochasticGuid => () => Guid.NewGuid().ToString("N").ToUpper(),
			EntityKeyGeneratorType.SequentialGuid => () => Guid.NewGuid().ToString("N").ToUpper(),
			EntityKeyGeneratorType.SequentialDate => () => DateTimeOffset.UtcNow.UtcTicks.ToString(),
			_                                     => throw new NotImplementedException()
		};
	}
}