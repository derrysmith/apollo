namespace Legenderry.Apollo.Extensions.Core.Entities;

/// <summary>
/// 
/// </summary>
public static class EntityKeyExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="value"></param>
	/// <param name="prefix"></param>
	/// <param name="suffix"></param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentException"></exception>
	public static string ExtractEntityKeyValue(string value, string prefix, string suffix)
	{
		var entityKeyValue = value;

		if (!string.IsNullOrEmpty(prefix) && !value.StartsWith(prefix))
			throw new System.ArgumentException($"Cannot parse '{value}', does not start with '{prefix}'.");

		if (!string.IsNullOrEmpty(suffix) && !value.EndsWith(suffix))
			throw new System.ArgumentException($"Cannot parse '{value}', does not end with '{suffix}'.");

		if (!string.IsNullOrEmpty(prefix) && value.StartsWith(prefix))
			entityKeyValue = entityKeyValue.Substring(prefix.Length);

		if (!string.IsNullOrEmpty(suffix) && value.EndsWith(suffix))
			entityKeyValue = entityKeyValue.Substring(0, entityKeyValue.Length - suffix.Length);

		return entityKeyValue;
	}
}