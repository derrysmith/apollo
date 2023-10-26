using Apollo.Identity.Core.Application.Entities;
using Apollo.Identity.Core.Domain;
using DS.Apollo.Core.Domain.Features;
using DS.Apollo.Core.Domain.Messages;
using DS.Apollo.Core.Domain.Services;

namespace Apollo.Identity.Core.Application.Features;

public interface IProfileContext : IEntityUnitOfWork
{
	IProfileRepository Profiles { get; }
	IIntegrationEventRepository IntegrationEvents { get; }
}

public record ProfileCreated : IIntegrationEvent;

public static class CreateProfile
{
	public record Command(
		UserProfile UserProfile, AuthProfile AuthProfile) : IFeatureCommand;

	public class Handler : FeatureCommandHandler<Command>
	{
		private readonly IProfileContext _context;
		
		public override async Task Handle(Command request, CancellationToken cancellationToken)
		{
			// create aggregate
			var profile = new Profile();
			
			// append aggregate
			_context.Profiles.Append(profile);
			
			// append events
			_context.IntegrationEvents.Append(new ProfileCreated());
			
			// commit aggregate
			await _context.CommitAsync(cancellationToken);
		}
	}
}