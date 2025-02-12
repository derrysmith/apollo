using Apollo.Libraries.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Apollo.Infrastructure.Data.EF;

public class EntityFxEntityKeyConverter<T> : ValueConverter<T, string>
	where T : EntityKey<T>, new()
{
	public EntityFxEntityKeyConverter()
		: base(id => id.ToString(), sql => EntityKey<T>.Parse(sql)) { }
}
