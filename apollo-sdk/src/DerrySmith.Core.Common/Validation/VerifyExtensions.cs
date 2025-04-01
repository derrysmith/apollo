using FluentValidation;

namespace DerrySmith.Core.Common.Validation;

public static partial class VerifyExtensions
{
	private static void Validate<T>(
		this IVerify<T> verify, Func<InlineValidator<IVerify<T>>, IRuleBuilderOptions<IVerify<T>, T>> rule)
	{
		try
		{
			var validator = new InlineValidator<IVerify<T>>();
			validator.Add(rule);

			validator.ValidateAndThrow(verify);
		}
		catch (ValidationException ex)
		{
			throw new ApplicationException(ex.Message, ex);
		}
	}
}
