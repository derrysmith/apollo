namespace DerrySmith.Core.Domain.Features;

public interface IFeatureRequestHandler<in TFeatureRequest, T> : MediatR.IRequestHandler<TFeatureRequest, T>
	where TFeatureRequest : IFeatureRequest<T>;
