namespace DerrySmith.Extensions.Common.Collections
{
	/// <summary>
	/// 
	/// </summary>
	public interface IPage
	{
		/// <summary>
		/// 
		/// </summary>
		int Count { get; }

		/// <summary>
		/// 
		/// </summary>
		int CurrentPage { get; }
	
		/// <summary>
		/// 
		/// </summary>
		int CurrentSize { get; }

		/// <summary>
		/// 
		/// </summary>
		bool HasPrevPage { get; }
	
		/// <summary>
		/// 
		/// </summary>
		bool HasNextPage { get; }

		/// <summary>
		/// 
		/// </summary>
		int TotalItems { get; }
	
		/// <summary>
		/// 
		/// </summary>
		int TotalPages { get; }
	}
}

namespace DerrySmith.Extensions.Common.Collections.Generic
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IPage<out T> : IPage
	{
		/// <summary>
		/// 
		/// </summary>
		IEnumerable<T> Items { get; }
	}
	
	/// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Page<T> : IPage<T>
    {
    	private readonly List<T> _items;
    	
    	private Page(IEnumerable<T> subset, int page, int size, int total)
    	{
    		if (subset is null) throw new InvalidOperationException();
    		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(page, nameof(page));
    		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size, nameof(size));
    		
    		_items = new List<T>(subset);
    
    		this.CurrentPage = page;
    		this.CurrentSize = size;
    
    		this.TotalItems = total;
    		this.TotalPages = (int)Math.Ceiling((double)total / size);
    
    		this.HasPrevPage = page > 1;
    		this.HasNextPage = page < this.TotalPages;
    	}
    
    	/// <inheritdoc />
    	public int CurrentPage { get; }
    	
    	/// <inheritdoc />
    	public int CurrentSize { get; }
    
    	/// <inheritdoc />
    	public bool HasPrevPage { get; }
    	
    	/// <inheritdoc />
    	public bool HasNextPage { get; }
    
    	/// <inheritdoc />
    	public int TotalItems { get; }
    	
    	/// <inheritdoc />
    	public int TotalPages { get; }
    
    	/// <inheritdoc />
    	public int            Count => _items.Count;
    	
    	/// <inheritdoc />
    	public IEnumerable<T> Items => _items.AsReadOnly();
    
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="source"></param>
    	/// <param name="page"></param>
    	/// <param name="size"></param>
    	/// <returns></returns>
    	internal static IPage<T> New(IEnumerable<T> source, int page, int size)
    	{
    		var subset = source.Skip((page - 1) * size).Take(size);
    		return new Page<T>(subset, page, size, source.Count());
    	}
    
    	/// <summary>
    	/// 
    	/// </summary>
    	/// <param name="subset"></param>
    	/// <param name="page"></param>
    	/// <param name="size"></param>
    	/// <param name="total"></param>
    	/// <returns></returns>
    	internal static IPage<T> New(IEnumerable<T> subset, int page, int size, int total)
    	{
    		return new Page<T>(subset, page, size, total);
    	}
    }
	
	/// <summary>
	/// 
	/// </summary>
	public static class PageExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <param name="page"></param>
		/// <param name="size"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IPage<T> Paged<T>(this IEnumerable<T> source, int page, int size)
			=> Page<T>.New(source, page, size);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="subset"></param>
		/// <param name="page"></param>
		/// <param name="size"></param>
		/// <param name="total"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IPage<T> Paged<T>(this IEnumerable<T> subset, int page, int size, int total)
			=> Page<T>.New(subset, page, size, total);
	}
}

namespace DerrySmith.Extensions.Common.Auditing
{
	/// <summary>
	/// 
	/// </summary>
	public interface IWasCreatedAt
	{
		/// <summary>
		/// 
		/// </summary>
		DateTimeOffset CreatedAt { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public interface IWasCreatedBy
	{
		/// <summary>
		/// 
		/// </summary>
		string? CreatedBy { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public interface IWasUpdatedAt
	{
		/// <summary>
		/// 
		/// </summary>
		DateTimeOffset? UpdatedAt { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public interface IWasUpdatedBy
	{
		/// <summary>
		/// 
		/// </summary>
		string? UpdatedBy { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public interface IWasDeletedAt
	{
		/// <summary>
		/// 
		/// </summary>
		DateTimeOffset? DeletedAt { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public interface IWasDeletedBy
	{
		/// <summary>
		/// 
		/// </summary>
		string? DeletedBy { get; }
	}
}

namespace DerrySmith.Extensions.Common.DateTime
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDateTimeService
	{
		/// <summary>
		/// 
		/// </summary>
		DateTimeOffset Now { get; }

		/// <summary>
		/// 
		/// </summary>
		DateTimeOffset UtcNow { get; }
	}

	/// <summary>
	/// 
	/// </summary>
	public static class DateTimeExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="dob"></param>
		/// <returns></returns>
		public static int Age(this System.DateTime dob)
		{
			return dob.Age(System.DateTime.UtcNow.Date);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dob"></param>
		/// <param name="now"></param>
		/// <returns></returns>
		public static int Age(this System.DateTime dob, System.DateTime now)
		{
			var age = now.Year - dob.Year;

			if (dob.Date > now.Date.AddYears(-age))
				age--;

			return age;
		}
	}

	/// <inheritdoc />
	public class DateTimeService : IDateTimeService
	{
		/// <inheritdoc />
		public DateTimeOffset Now => DateTimeOffset.Now;

		/// <inheritdoc />
		public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
	}
}