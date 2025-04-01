namespace DerrySmith.Core.Common.Validation;

public interface IVerifyBuilder<out T>
{
	IVerify<T> Is    { get; }
	IVerify<T> IsNot { get; }
}
