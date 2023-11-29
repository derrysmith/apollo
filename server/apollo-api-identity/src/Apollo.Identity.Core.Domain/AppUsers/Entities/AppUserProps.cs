using System.Text.Json.Serialization;

namespace Apollo.Identity.Core.Domain.AppUsers.Entities;

public record AppUserProps
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }
	
	[JsonPropertyName("fname")]
	public string? FName { get; set; }
	
	[JsonPropertyName("lname")]
	public string? LName { get; set; }

	[JsonPropertyName("auth_provider_name")]
	public string? AuthProviderName { get; set; }
	
	[JsonPropertyName("auth_provider_type")]
	public string? AuthProviderType { get; set; }
	
	[JsonPropertyName("auth_provider_user_id")]
	public string? AuthProviderUserId { get; set; }
	
	[JsonPropertyName("auth_provider_user_name")]
	public string? AuthProviderUserName { get; set; }

	[JsonPropertyName("email")]
	public string? EmailAddress { get; set; }
	
	[JsonPropertyName("email_verified")]
	public bool? EmailIsVerified { get; set; }
		
	[JsonPropertyName("phone")]
	public string? PhoneNumber { get; set; }
	
	[JsonPropertyName("phone_verified")]
	public bool? PhoneIsVerified { get; set; }
}