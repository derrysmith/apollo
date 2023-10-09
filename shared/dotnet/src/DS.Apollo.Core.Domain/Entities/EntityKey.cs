namespace DS.Apollo.Core.Domain.Entities;

public abstract record EntityKey<T> : IEntityKey
	where T : notnull
{
	private readonly T _value;

	protected EntityKey(T value)
		=> _value = value;

	public static implicit operator string(EntityKey<T> entity)
		=> entity.ToString();

	public static implicit operator T(EntityKey<T> entity)
		=> entity._value;
}