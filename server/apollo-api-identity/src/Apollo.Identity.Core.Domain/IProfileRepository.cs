using DS.Apollo.Core.Domain.Services;

namespace Apollo.Identity.Core.Domain;

public interface IProfileRepository : IEntityRepository<Profile, ProfileKey>
{
}