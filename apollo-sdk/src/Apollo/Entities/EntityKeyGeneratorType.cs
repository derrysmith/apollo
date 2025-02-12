namespace Apollo.Entities;

/// <summary>
/// Determines the way in which the raw value of the identifier is generated.
/// </summary>
public enum EntityKeyGeneratorType
{
	SequentialGuid = 1,
	SequentialDate = 2,
	StochasticGuid = 3,
}
