namespace DS.Apollo.Core.Domain.Features;

public abstract class FeatureCommandHandler<T> : MediatR.IRequestHandler<T>
	where T : IFeatureCommand
{
	public abstract Task Handle(T request, CancellationToken cancellationToken);
}