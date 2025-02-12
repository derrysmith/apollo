using Apollo.Core.Domain.Identity.Entities;

namespace Apollo.Core.Application.Identity.Features;

public static class CreateUserProfile
{
	public record Command : MediatR.IRequest<UserProfileId>;

	public class Handler : MediatR.IRequestHandler<Command, UserProfileId>
	{
		private readonly IUserProfileRepository _repository;

		public Handler(IUserProfileRepository repository)
		{
			_repository = repository;
		}

		public async Task<UserProfileId> Handle(Command request, CancellationToken cancellationToken)
		{
			// create the aggregate root
			var userProfile = UserProfile.Create();
			
			// append entity
			_repository.Append(userProfile);
			
			// append events
			
			// publish domain events (by saving the unit-of-work
			await _repository.UoW.CommitAsync(cancellationToken);

			return userProfile.Id;
		}
	}
}
