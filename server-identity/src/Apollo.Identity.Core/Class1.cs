namespace Apollo.Identity.Core.Services
{
	public interface IMessagePublisher
	{
		Task PublishAsync<T>(T message, CancellationToken cancellationToken = default);
	}
}

namespace Apollo.Identity.Core.Messages
{
	public class UserRegistered
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;

		public string IdentityProvider { get; set; } = string.Empty;
		public string IdentityProviderId { get; set; } = string.Empty;

		public DateTimeOffset RegistrationDate { get; set; }
		// email-password|social-google|social-facebook|social-twitter
		public string RegistrationType { get; set; } = string.Empty;
	}
}