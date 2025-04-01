namespace DerrySmith.Core.Common.Validation;

internal class VerifyBuilder<T> : IVerifyBuilder<T>
{
	private readonly T _value;

	public VerifyBuilder(T value)
		=> _value = value;

	public IVerify<T> Is
		=> new Verify<T>(_value);

	public IVerify<T> IsNot
		=> new Verify<T>(_value, true);
}
