using Apollo.Core.Domain.Identity.Messages;
using Microsoft.Extensions.Logging;

namespace Apollo.Core.Application.Contacts.Handlers;

public static class OnUserProfileCreated
{
	public class CreateDefaultContact : MediatR.INotificationHandler<UserProfileCreated>
	{
		private readonly ILogger _logger;

		public CreateDefaultContact(ILogger<CreateDefaultContact> logger)
		{
			_logger = logger;
		}

		public async Task Handle(UserProfileCreated notification, CancellationToken cancellationToken)
		{
			_logger.LogDebug("handling UserProfileCreated domain event {notification}", notification);
		}
	}
}
