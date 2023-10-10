namespace Apollo.Identity.Core.Domain.Models;

public record ProfileLogin(
	string UserId,
	string UserName,
	string ProviderName,
	string ProviderType);