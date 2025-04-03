using DerrySmith.Extensions.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerrySmith.Extensions.Domain.EntityFrameworkCore;

public static class EntityFxCoreDbContextExtensions
{
	public static PropertiesConfigurationBuilder<TEntityKey> AreEntityKey<TEntityKey>(
		this PropertiesConfigurationBuilder<TEntityKey> builder)
		where TEntityKey : EntityKey<TEntityKey>, new()
	{
		return builder.HaveConversion<EntityFxCoreEntityKeyConverter<TEntityKey>>()
					  .AreUnicode()
					  .HaveMaxLength(64);
	}
}
