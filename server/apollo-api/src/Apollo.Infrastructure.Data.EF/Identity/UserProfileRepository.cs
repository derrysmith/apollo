using Apollo.Core.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Infrastructure.Data.EF.Identity;

public class UserProfileRepository(ApolloDbContext context)
	: EntityFxRepository<UserProfile, UserProfileId>(context), IUserProfileRepository
{
	public async Task<UserProfile?> GetAsync(string authIssuer, string authUserId, CancellationToken ct = default)
	{
		return await this.DbContext.UserProfiles.SingleOrDefaultAsync(e =>
			e.Login != null && e.Login.AuthIssuer == authIssuer && e.Login.AuthUserId == authUserId, ct);
	}
}
