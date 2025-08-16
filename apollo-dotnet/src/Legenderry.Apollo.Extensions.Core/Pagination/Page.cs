using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

public class Page<T> : IPage<T>
{
	private List<T> _items;

	public int Count => _items.Count;

	public int  CurrentPage     { get; private set; }
	public int  CurrentPageSize { get; private set; }
	public bool HasPrevPage     { get; private set; }
	public bool HasNextPage     { get; private set; }
	public int  TotalItems      { get; private set; }
	public int  TotalPages      { get; private set; }

	public Page(IEnumerable<T> source, int page, int pageSize)
	{
		var items  = source.ToList();
		var subset = items.Skip((page - 1) * pageSize).Take(pageSize);
		
		this.Initialize(subset, page, pageSize, items.Count);
	}

	public Page(IEnumerable<T> subset, int page, int pageSize, int total)
	{
		this.Initialize(subset, page, pageSize, total);
	}

	public IEnumerator<T> GetEnumerator()
		=> _items.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
		=> this.GetEnumerator();

	[MemberNotNull(nameof(_items))]
	private void Initialize(IEnumerable<T> subset, int page, int pageSize, int total)
	{
		_items = new List<T>(subset);

		this.CurrentPage     = page;
		this.CurrentPageSize = pageSize;

		this.TotalItems = total;
		this.TotalPages = (int)Math.Ceiling((double)total / pageSize);

		this.HasPrevPage = this.CurrentPage > 1;
		this.HasNextPage = this.CurrentPage < this.TotalPages;
	}
}