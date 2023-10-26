namespace Apollo.Identity.Core.Application.Entities;

public class UserProfile
{
	public string? Id { get; set; }

	public string? FirstName { get; set; }
	public string? LastName { get; set; }

	public string? EmailAddress { get; set; }
	public bool? EmailIsVerified { get; set; }

	public string? PhoneNumber { get; set; }
	public bool? PhoneIsVerified { get; set; }
}