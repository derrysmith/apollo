using System.Text.Json.Serialization;
using Apollo.Identity.Core.Messages;
using Apollo.Identity.Core.Services;

namespace Apollo.Identity.Worker.Api.Hooks.Routes;

public static class PostUserRegistrationRoute
{
	public const string PathTemplate = "auth0/post-user-registration";

	public class Payload : MediatR.IRequest
	{
		[JsonPropertyName("fname")]
		public string? FirstName { get; set; }

		[JsonPropertyName("lname")]
		public string? LastName { get; set; }
	}

	public class Handler : MediatR.IRequestHandler<Payload>
	{
		private readonly IMessagePublisher _publisher;
				
		public async Task<MediatR.Unit> Handle(Payload request, CancellationToken cancellationToken)
		{
			// convert payload into domain event
			var userRegistered = new UserRegistered();
					
			// publish domain event
			await _publisher.PublishAsync(userRegistered, cancellationToken);

			return MediatR.Unit.Value;
		}
	}
}