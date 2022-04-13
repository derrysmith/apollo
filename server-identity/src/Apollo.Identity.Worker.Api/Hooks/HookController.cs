using Apollo.Identity.Worker.Api.Hooks.Routes;
using Microsoft.AspNetCore.Mvc;

namespace Apollo.Identity.Worker.Api.Hooks;

[Route(BasePathTemplate)]
public class HookController : ControllerBase
{
	private readonly MediatR.IMediator _mediator;

	public HookController(MediatR.IMediator mediator)
	{
		_mediator = mediator;
	}

	private const string BasePathTemplate = "hooks";

	public async Task<IActionResult> HandleAsync([FromBody] PostUserRegistrationRoute.Payload payload,
		CancellationToken cancellationToken)
	{
		// handle webhook payload from Auth0
		await _mediator.Send(payload, cancellationToken);

		return this.StatusCode(StatusCodes.Status202Accepted);
	}
}