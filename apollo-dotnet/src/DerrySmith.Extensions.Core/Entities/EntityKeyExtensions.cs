using System.Reflection;

namespace DerrySmith.Extensions.Core.Entities;

/// <summary></summary>
public static class EntityKeyExtensions
{
	/// <summary></summary>
	/// <param name="entityKeyType"></param>
	/// <returns></returns>
	public static EntityKeyAttribute GetEntityKeyAttribute(this Type entityKeyType)
		=> entityKeyType.GetCustomAttribute<EntityKeyAttribute>() ?? new EntityKeyAttribute();
}