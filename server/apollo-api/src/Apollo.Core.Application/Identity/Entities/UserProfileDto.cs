using System.Text.Json.Serialization;
using Apollo.Core.Domain.Identity.Entities;

namespace Apollo.Core.Application.Identity.Entities;

public record UserProfileDto
{
	[JsonPropertyName("id")]
	public string Id { get; set; } = default!;

	[JsonPropertyName("display_name")]
	public string DisplayName { get; set; } = default!;
	
	[JsonPropertyName("description")]
	public string Description { get; set; } = default!;

	[JsonPropertyName("email")]
	public string? Email { get; set; }
	
	[JsonPropertyName("phone")]
	public string? Phone { get; set; }

	public static implicit operator UserProfileDto(UserProfile profile)
	{
		return new UserProfileDto
		{
			Id          = profile.Id.ToString(),
			DisplayName = profile.DisplayName,
			Description = profile.Description,
			Email       = profile.Email?.Address,
			Phone       = profile.Phone?.Number,
		};
	}
}
