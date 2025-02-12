using Apollo.Core.Application.Identity.Entities;
using Apollo.Core.Application.Identity.Features;
using Apollo.Core.Domain.Identity.Entities;
using Apollo.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Api.Identity.Routes;

// CreateUserProfileRoute (POST: /identity/users)
// GetUserProfileRoute (GET: /identity/users/{id})
// AddUserProfileEmailRoute (POST: /identity/users/{id}/emails)
// AddUserProfilePhoneRoute (POST: /identity/users/{id}phones)
// VerifyUserProfileEmailRoute (PATCH: /identity/users/{id}

public static class CreateUserProfileRoute
{
	public record Request() : MediatR.IRequest<Response>;

	public record Response(string UserProfileId);
	
	public class Handler : MediatR.IRequestHandler<Request, Response>
	{
		private readonly ApolloDbContext _context;

		public Handler(ApolloDbContext context)
		{
			_context = context;
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			var createUserProfileCommand = new CreateUserProfile().Command();
			var createUserProfileResponse = await 
			var command       = new CreateUserProfile.Command();
			var userProfileId = await mediator.Send(command, ct);
			var userProfile   = await context.UserProfiles.AsNoTracking().SingleAsync(u => u.Id == userProfileId, ct);

			return userProfile!;
		}
	}
}
public static class GetUserProfileRoute
{
	public record Request(string UserProfileId) : MediatR.IRequest<Response>;

	public record Response(UserProfileDto UserProfile);

	public class Handler : MediatR.IRequestHandler<Request, Response>
	{
		private readonly ApolloDbContext _context;

		public Handler(ApolloDbContext context)
		{
			_context = context;
		}

		public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
		{
			var userProfileId = UserProfileId.Parse(request.UserProfileId);
			var userProfile = await _context.UserProfiles.AsNoTracking()
											.SingleAsync(p => p.Id == userProfileId, cancellationToken);

			return new Response(userProfile);
		}
	}
}
