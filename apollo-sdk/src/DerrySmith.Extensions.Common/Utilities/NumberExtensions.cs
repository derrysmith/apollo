namespace DerrySmith.Extensions.Common.Utilities;

public static class NumberExtensions
{
	private static readonly string[] _ones =
	[
		"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
		"Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
	];

	private static readonly string[] _tens =
	[
		"", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
	];

	private static readonly string[] _groups =
	[
		"", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion",
		// the following exceed the maximum value of the long data type, so will never be used anyway
		// just here for completeness in case we get bigger data types
		"Sextillion",
		"Septillion",
		"Octillion",
		"Nonillion",
		"Decillion",
		"Undecillion",
		"Dodecillion",
		"Tredecillion",
		"Quattuordecillion",
	];

	public static string ToEnglish(this short number)
		=> ((long)number).ToEnglish();

	public static string ToEnglish(this int number)
		=> ((long)number).ToEnglish();

	public static string ToEnglish(this long number)
	{
		var x = long.MaxValue;
		return number switch
		{
			< 20   => _ones[number],
			< 100  => GetTensString(number),
			< 1000 => GetHundredsString(number),
			_      => GetGroupedString(number)
		};
	}

	private static string GetTensString(long number)
	{
		var x = number / 10;
		var y = number % 10;

		return _tens[x] + (y > 0 ? "-" + _ones[y] : string.Empty);
	}

	private static string GetHundredsString(long number)
	{
		var h = number / 100;
		var x = number % 100;

		return _ones[h] + " Hundred" + (x > 0 ? " and " + x.ToEnglish() : string.Empty);
	}

	private static string GetGroupedString(long number)
	{
		var b = new List<string>();
		
		while (number > 0)
		{
			var r = number % 1000; // 789|456|123

			// append 234
			b.Add(r > 0 ? r.ToEnglish() : string.Empty); // Seven Hundred and Eight-Nine|Four Hundred and Fifty-Six|One Hundred and Twenty-Three

			number = (number - r) / 1000; // 123,456|123|0
		}
		
		// add groupings
		for (var g = 0; g < b.Count; g++)
			b[g] += (g > 0 ? " " : "") + _groups[g];
		
		// remove empty groups
		b.RemoveAll(string.IsNullOrEmpty);

		// reverse collection of groups
		b.Reverse();
		
		return string.Join(", ", b);
	}
}
