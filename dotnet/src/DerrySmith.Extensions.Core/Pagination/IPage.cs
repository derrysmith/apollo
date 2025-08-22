// ReSharper disable once CheckNamespace
namespace System.Collections.Generic;

public interface IPage<out T> : IReadOnlyCollection<T>
{
	int CurrentPage     { get; }
	int CurrentPageSize { get; }

	bool HasPrevPage { get; }
	bool HasNextPage { get; }

	int TotalItems { get; }
	int TotalPages { get; }
}