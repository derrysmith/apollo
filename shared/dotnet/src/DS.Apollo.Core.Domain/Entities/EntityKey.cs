namespace DS.Apollo.Core.Domain.Entities;

public abstract record EntityKey<T> : IEntityKey
{
	private readonly T _value;

	protected EntityKey(T value)
		=> _value = value;

	public static implicit operator string(EntityKey<T> entity)
		=> entity._value.ToString()!;

	public static implicit operator T(EntityKey<T> entity)
		=> entity._value;
}