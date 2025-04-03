using DerrySmith.Extensions.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DerrySmith.Extensions.Domain.EntityFrameworkCore;

public class EntityFxCoreEntityKeyConverter<TEntityKey> : ValueConverter<TEntityKey, string>
	where TEntityKey : EntityKey<TEntityKey>, new()
{
	public EntityFxCoreEntityKeyConverter()
		: base(key => key.ToString(), val => EntityKey<TEntityKey>.Parse(val)) { }
}
