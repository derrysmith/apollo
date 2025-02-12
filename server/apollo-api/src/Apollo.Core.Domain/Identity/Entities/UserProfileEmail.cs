namespace Apollo.Core.Domain.Identity.Entities;

public record UserProfileEmail
(
	string Address,
	bool   IsVerified
);
