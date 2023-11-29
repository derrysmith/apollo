using Apollo.Identity.Core.Application.AppUsers.Messages;

namespace Apollo.Identity.Api.WebHooks;

[Route(BaseTemplatePath)]
public class WebHookController : ControllerBase
{
	private readonly MediatR.IMediator _mediator;
	
	public WebHookController(MediatR.IMediator mediator)
		=> _mediator = mediator;

	private const string BaseTemplatePath = "hooks";

	[HttpGet("date")]
	[Produces(Globals.JsonContentType)]
	public IActionResult Date()
	{
		return this.Ok(DateTimeOffset.UtcNow);
	}

	[HttpGet("ping")]
	[Produces(Globals.JsonContentType)]
	public IActionResult Ping()
	{
		return this.Ok("OK");
	}

	[HttpPost]
	[Consumes(Globals.JsonContentType)]
	[Produces(Globals.JsonContentType)]
	public async Task<IActionResult> PostSignInAsync([FromBody] PostSignInPayload payload, CancellationToken ct)
	{
		// publish AppUserAuthenticated integration event
		var appUserAuthenticated = new UserAuthenticated
		{
			FirstName = payload.FirstName,
			LastName = payload.LastName,
			ProviderName = "auth0",
			ProviderType = "social",
			UserId = "auth0|1234",
			UserName = $"{payload.FirstName}_{payload.LastName}".ToLower()
		};
		
		await _mediator.Publish(appUserAuthenticated, ct);
		
		return this.StatusCode(StatusCodes.Status202Accepted);
	}
}

public record PostSignInPayload
{
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
}