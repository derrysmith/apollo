using Apollo.Identity.Core.Application.AppUsers.Features;
using Apollo.Identity.Core.Application.AppUsers.Messages;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using MediatR;

namespace Apollo.Identity.Core.Application.AppUsers.Handlers;

public static class OnUserAuthenticated
{
	public class AddNewAppUser : MediatR.INotificationHandler<UserAuthenticated>
	{
		private readonly MediatR.IMediator _mediator;

		public AddNewAppUser(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task Handle(UserAuthenticated notification, CancellationToken cancellationToken)
		{
			var props = new AppUserProps
			{
				FName = notification.FirstName,
				LName = notification.LastName,
				AuthProviderName = notification.ProviderName,
				AuthProviderType = notification.ProviderType,
				AuthProviderUserId = notification.UserId,
				AuthProviderUserName = notification.UserName,
				EmailAddress = notification.EmailAddress,
				EmailIsVerified = notification.EmailIsVerified,
				PhoneNumber = notification.PhoneNumber,
				PhoneIsVerified = notification.PhoneIsVerified
			};

			var createAppUserCommand = new CreateAppUser.Command(props);
			await _mediator.Send(createAppUserCommand, cancellationToken);
		}
	}
}