namespace Apollo.Extensions.Core.Entities;

public interface IEntityKey<TEntityKey>
	where TEntityKey : IEntityKey<TEntityKey>
{
	static abstract TEntityKey New();

	static abstract TEntityKey Parse(string value);

	static abstract bool TryParse(string value, out TEntityKey entityKey);
}