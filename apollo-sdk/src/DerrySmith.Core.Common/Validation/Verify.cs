namespace DerrySmith.Core.Common.Validation;

public static class Verify
{
	public static IVerifyBuilder<T> That<T>(T obj) => new VerifyBuilder<T>(obj);
}

internal class Verify<T> : IVerify<T>
{
	public Verify(T value, bool isNot = false)
	{
		this.Value     = value;
		this.IsNotFlag = isNot;
	}

	public T Value { get; }

	public bool IsNotFlag { get; private set; }
}
