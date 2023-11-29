// using Apollo.Identity.Core.Application.Features;
// using Apollo.Identity.Core.Domain.Models;
//
// namespace Apollo.Identity.Api.AppUsers;
//
// [Route(BaseTemplatePath)]
// public class AppUserController : ControllerBase
// {
// 	private readonly MediatR.IMediator _mediator;
//
// 	public AppUserController(MediatR.IMediator mediator)
// 		=> _mediator = mediator;
//
// 	private const string BaseTemplatePath = "users";
// 	
// 	[HttpPost]
// 	[Consumes(Globals.JsonContentType)]
// 	[Produces(Globals.JsonContentType)]
// 	public async Task<IActionResult> CreateAppUserAsync([FromBody] CreateAppUserRequest request, CancellationToken ct)
// 	{
// 		var createAppUserCommand = new CreateAppUser.Command(request);
// 		await _mediator.Send(createAppUserCommand, ct);
//
// 		return this.StatusCode(StatusCodes.Status202Accepted);
// 	}
// }