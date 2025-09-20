namespace Apollo.Libraries.Core.Entities;

public interface IEntityKey<T> where T : struct, IEntityKey<T>
{
	static abstract T New();

	static abstract T Parse(string value);

	static abstract bool TryParse(string value, out T entityKey);
}