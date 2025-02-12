namespace Apollo.Core.Domain.Identity.Entities;

public record UserProfileLogin
(
	string AuthIssuer,
	string AuthUserId
);