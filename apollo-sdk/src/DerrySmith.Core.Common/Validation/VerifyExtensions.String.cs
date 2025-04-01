namespace DerrySmith.Core.Common.Validation;

public static partial class VerifyExtensions
{
	public static void NullOrEmpty(this IVerify<string> verify)
	{
		// value = "", IsNotFlag = false, string.IsNullOrEmpty = true, expected = true
		// value = "", IsNotFlag = true, string.IsNullOrEmpty = true, expected = false
		// value = "abc", IsNotFlag = false, string.IsNullOrEmpty = false, expected = false
		// value = "abc", IsNotFlag = true, string.IsNullOrEmpty = false, expected = true
		
		// use exclusive or (XOR)
		if (string.IsNullOrEmpty(verify.Value) ^ !verify.IsNotFlag)
			throw new ApplicationException();
	}

	public static void NullOrWhiteSpace(this IVerify<string> verify)
	{
		// value = " ", IsNotFlag = false, string.IsNullOrWhiteSpace = true, expected = true
		// value = " ", IsNotFlag = true, string.IsNullOrWhiteSpace = true, expected = false
		// value = "abc", IsNotFlag = false, string.IsNullOrWhiteSpace = false, expected = false
		// value = "abc", IsNotFlag = true, string.IsNullOrWhiteSpace = false, expected = true

		// use exclusive or (XOR)
		if (string.IsNullOrWhiteSpace(verify.Value) ^ !verify.IsNotFlag)
			throw new ApplicationException();
	}
}