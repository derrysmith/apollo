namespace DerrySmith.Core.Common.Dates;

public static class DateTimeExtensions
{
	public static DateTimeOffset Tomorrow(this DateTimeOffset date)
		=> date.AddDays(1);
	
	public static DateTimeOffset Yesterday(this DateTimeOffset date)
		=> date.AddDays(-1);

	public static DateTimeOffset NextYear(this DateTimeOffset date)
		=> date.AddYears(1);

	public static DateTimeOffset LastYear(this DateTimeOffset date)
		=> date.AddYears(-1);
}
