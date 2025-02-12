using Apollo.Api.Identity.Routes;
using Apollo.Core.Application.Identity.Entities;
using Apollo.Core.Application.Identity.Features;
using Apollo.Core.Domain.Identity.Entities;
using Apollo.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Apollo.Api.Identity;

public static class IdentityRouting
{
	public static void MapIdentityRoutes(this IEndpointRouteBuilder builder)
	{
		var group = builder.MapGroup("/identity");

		// POST: /identity/users
		group.MapPost("/users", IdentityRouting.CreateUserProfileAsync);
		
		// PUT: /identity/users/:id
		group.MapGet("/users/{userProfileId}", IdentityRouting.GetUserProfileAsync);
		
		// PUT: /identity/users/:id
		group.MapPut("/users/{userProfileId}", IdentityRouting.UpdateUserProfileAsync);

		// GET: /identity/users/:id
		group.MapGet("/users/{userProfileId}", async (string userProfileId, MediatR.IMediator mediator, CancellationToken ct) =>
		{
			var getUserProfileRequest  = new GetUserProfileRoute.Request(userProfileId);
			var getUserProfileResponse = await mediator.Send(getUserProfileRequest, ct);

			return getUserProfileResponse;
		});
	}

	private static async Task<object> CreateUserProfileAsync(
		object createUserProfileRequest, MediatR.IMediator mediator, CancellationToken ct)
	{
		var createUserProfileResponse = await mediator.Send(createUserProfileRequest, ct);

		return createUserProfileResponse;
	}

	private static async Task GetUserProfileAsync(
		string userProfileId, MediatR.IMediator mediator, CancellationToken ct) { }

	private static async Task UpdateUserProfileAsync(
		object updateUserProfileRequest, MediatR.IMediator mediator, CancellationToken ct)
	{
		// UpdateUserProfile.Request
		// UpdateUserProfile.Response
		var response = await mediator.Send(request, ct);
	}

	private static async Task<UserProfileDto> CreateUserProfileRouteHandler(
		MediatR.IMediator mediator, ApolloDbContext context, CancellationToken ct)
	{
		var command       = new CreateUserProfile.Command();
		var userProfileId = await mediator.Send(command, ct);
		var userProfile   = await context.UserProfiles.AsNoTracking().SingleAsync(u => u.Id == userProfileId, ct);

		return userProfile!;
	}

	private static async Task<UserProfileDto> GetUserProfileRouteHandler(
		string id, ApolloDbContext context, CancellationToken ct)
	{
		var userProfileId = UserProfileId.Parse(id);
		var userProfile   = await context.UserProfiles.AsNoTracking().SingleAsync(p => p.Id == userProfileId, ct);

		return userProfile;
	}
}
