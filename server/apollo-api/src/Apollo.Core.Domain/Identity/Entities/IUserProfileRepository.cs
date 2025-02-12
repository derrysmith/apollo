using Apollo.Libraries.Core.Domain.Entities;

namespace Apollo.Core.Domain.Identity.Entities;

public interface IUserProfileRepository : IEntityRepository<UserProfile, UserProfileId>
{
	Task<UserProfile?> GetAsync(string authIssuer, string authUserId, CancellationToken ct = default);
}