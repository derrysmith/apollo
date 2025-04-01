namespace DerrySmith.Core.Domain.Features;

public interface IFeatureRequest<out T> : MediatR.IRequest<T>;
