namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public record AppUserPhone(
	string Number, bool IsVerified);