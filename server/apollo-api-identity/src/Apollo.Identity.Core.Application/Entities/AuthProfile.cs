namespace Apollo.Identity.Core.Application.Entities;

public class AuthProfile
{
	public string? UserId { get; set; }
	public string? UserName { get; set; }
	public string? ProviderName { get; set; }
	public string? ProviderType { get; set; }
}