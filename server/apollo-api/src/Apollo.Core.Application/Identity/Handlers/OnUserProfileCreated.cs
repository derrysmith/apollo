using Apollo.Core.Domain.Identity.Messages;
using Apollo.Libraries.Core.Domain.Handlers;
using Microsoft.Extensions.Logging;

namespace Apollo.Core.Application.Identity.Handlers;

public static class OnUserProfileCreated
{
	public class UpdateAuthProfile : IDomainEventHandler<UserProfileCreated>
	{
		private readonly ILogger _logger;

		public UpdateAuthProfile(ILogger<UpdateAuthProfile> logger)
		{
			_logger = logger;
		}

		public async Task Handle(UserProfileCreated notification, CancellationToken cancellationToken)
		{
			_logger.LogDebug("handling UserProfileCreated domain event {notification}", notification);
			// do not commit any unit-of-work in the handlers, only in the command handlers that initiated it
		}
	}
}