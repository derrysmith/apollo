namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TEntityKey"></typeparam>
public interface IEntityRepository<TEntity, in TEntityKey>
	where TEntity : IEntity<TEntityKey>
{
	/// <summary></summary>
	/// <param name="id"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<TEntity?> FindAsync(TEntityKey id, CancellationToken ct = default);
	
	/// <summary></summary>
	/// <param name="id"></param>
	/// <param name="ct"></param>
	/// <returns></returns>
	Task<TEntity> GetAsync(TEntityKey id, CancellationToken ct = default);

	/// <summary></summary>
	/// <param name="entity"></param>
	void Append(TEntity entity);

	/// <summary></summary>
	/// <param name="entity"></param>
	void Update(TEntity entity);

	/// <summary></summary>
	/// <param name="id"></param>
	void Remove(TEntityKey id);
}