using MediatR;

namespace DerrySmith.Core.Domain.Features;

public interface IFeatureCommandHandler<in TFeatureCommand> : MediatR.IRequestHandler<TFeatureCommand>
	where TFeatureCommand : IFeatureCommand;

public sealed class FeatureCommandValidationBehavior<TFeatureCommand> : IPipelineBehavior<TFeatureCommand, Unit>
	where TFeatureCommand : IFeatureCommand
{
	public async Task<Unit> Handle(TFeatureCommand request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}