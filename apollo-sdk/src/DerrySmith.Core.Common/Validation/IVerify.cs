namespace DerrySmith.Core.Common.Validation;

public interface IVerify<out T>
{
	T Value { get; }

	internal bool IsNotFlag { get; }
}
