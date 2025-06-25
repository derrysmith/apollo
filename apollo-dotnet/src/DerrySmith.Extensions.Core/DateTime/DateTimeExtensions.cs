namespace DerrySmith.Extensions.Core.DateTime;

/// <summary></summary>
public static class DateTimeExtensions
{
	/// <summary></summary>
	/// <param name="dob"></param>
	/// <param name="date"></param>
	/// <returns></returns>
	public static int GetAge(this System.DateTime dob, System.DateTime? date = null)
	{
		var nowAsInt = int.Parse(date.GetValueOrDefault(System.DateTime.Now).ToString("yyyyMMdd"));
		var dobAsInt = int.Parse(dob.ToString("yyyyMMdd"));

		return (nowAsInt - dobAsInt) / 10000;
	}
}