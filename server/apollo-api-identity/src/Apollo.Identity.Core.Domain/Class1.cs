namespace Apollo.Core.Domain
{
	public interface IEntity<out TEntityKey>
	{
		TEntityKey Id { get; }
	}

	public interface IEntityKeyFactory
	{
		TEntityKey New<TEntityKey>()
			where TEntityKey : EntityKey;
	}

	public abstract class Entity<TEntityKey> : IEntity<TEntityKey>
	{
		public virtual TEntityKey Id { get; protected set; } = default!;
	}

	public abstract record EntityKey
	{
		private readonly string _value;

		protected EntityKey(string value)
			=> _value = value;

		public static implicit operator string(EntityKey id)
			=> id.ToString();

		public sealed override string ToString()
			=> _value;
	}

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class EntityKeyAttribute : Attribute
	{
		public EntityKeyAttribute(string prefix)
			=> this.Prefix = prefix;
		public string Prefix { get; }
	}

	public class EntityKeyFactory : IEntityKeyFactory
	{
		public TEntityKey New<TEntityKey>() where TEntityKey : EntityKey
		{
			throw new NotImplementedException();
		}
	}
}

namespace Apollo.Core.Values
{
	public interface ISequentialValueProvider<out T>
	{
		T Next();
	}

	public interface IStochasticValueProvider<out T>
	{
		T New();
	}
}