using Apollo.Identity.Core.Application.AppUsers.Services;
using Apollo.Identity.Core.Domain.AppUsers.Entities;
using Apollo.Identity.Core.Domain.AppUsers.Services;

namespace Apollo.Identity.Core.Application.AppUsers.Features;

public static class CreateAppUser
{
	public record Command(AppUserProps AppUser) : MediatR.IRequest;
	
	public class Handler : MediatR.IRequestHandler<Command>
	{
		private readonly IAppUserContext _context;
		private readonly IAppUserFactory _factory;

		public Handler(IAppUserContext context, IAppUserFactory factory)
		{
			_context = context;
			_factory = factory;
		}

		public async Task Handle(Command request, CancellationToken cancellationToken)
		{
			// create user profile
			var appUser = _factory.Create(request.AppUser);
			
			// append user profile
			_context.AppUsers.Append(appUser);
			
			// commit user profile
			await _context.CommitAsync(cancellationToken);
		}
	}
}