namespace Apollo.Identity.Core.Application.AppUsers.Messages;

public record UserAuthenticated() : MediatR.INotification
{
	public string? FullName { get; set; }
	public string? Nickname { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	
	public string? EmailAddress { get; set; }
	public bool? EmailIsVerified { get; set; }

	public string? PhoneNumber { get; set; }
	public bool? PhoneIsVerified { get; set; }

	public string? ImageUrl { get; set; }

	public string? UserId { get; set; }
	public string? UserName { get; set; }

	public string ProviderName { get; set; }
	public string ProviderType { get; set; }

	public DateTimeOffset CreatedAt { get; set; }
	public DateTimeOffset UpdatedAt { get; set; }
}