namespace DerrySmith.Apollo.Extensions.Core.Entities;

/// <summary>
/// Represents a method that extracts the raw entity key value from the formatted value.
/// </summary>
/// <param name="value">The formatted entity key value.</param>
public delegate string EntityKeyValueExtractor(string value);