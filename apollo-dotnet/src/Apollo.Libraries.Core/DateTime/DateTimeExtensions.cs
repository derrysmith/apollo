namespace Apollo.Libraries.Core.DateTime;

public static class DateTimeExtensions
{
	public static int GetAge(this DateOnly birthdate, DateOnly? date = null, IDateTimeProvider? provider = null)
	{
		var dtm      = provider ?? new DateTimeProvider();
		var now      = date.GetValueOrDefault(DateOnly.FromDateTime(dtm.Now.DateTime)).ToString("yyyyMMdd");
		var dob      = birthdate.ToString("yyyyMMdd");
		var nowAsInt = int.Parse(now);
		var dobAsInt = int.Parse(dob);

		return (nowAsInt - dobAsInt) / 10000;
	}
}