using System.Numerics;

namespace DerrySmith.Core.Common.Validation;

public static partial class VerifyExtensions
{
	public static void GreaterThan<T>(this IVerify<T> verify, T compare, string? message = default)
		where T : INumber<T>
	{
		// value = 0, IsNotFlag = false, > 123 = false, expected = false
		// value = 0, IsNotFlag = true, > 123 = false, expected = true
		// value = 456, IsNotFlag = false, > 123 = true, expected = true
		// value = 456, IsNotFlag = true, > 123 = true, expected = false

		// use exclusive or (XOR)
		if ((verify.Value > compare) ^ !verify.IsNotFlag)
			throw new ApplicationException(message);
	}
}
