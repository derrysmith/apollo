namespace Apollo.Core.Domain.Identity.Entities;

public record UserProfilePhone
(
	string Number,
	bool   IsVerified
);
