namespace Apollo.Libraries.Core.Common.Providers;

public interface IDateTimeProvider
{
	DateTimeOffset Now    { get; }
	DateTimeOffset UtcNow { get; }
}

public interface ISequentialValueProvider<out T>
{
	T Next();
}

public interface IStochasticValueProvider<out T>
{
	T New();
}