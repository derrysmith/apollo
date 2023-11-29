namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public record AppUserEmail(
	string Address, bool IsVerified);