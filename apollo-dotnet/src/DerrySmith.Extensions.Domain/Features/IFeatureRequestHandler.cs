namespace DerrySmith.Extensions.Domain.Features;

public interface IFeatureRequestHandler<TReq, T>
	where TReq : IFeatureRequest<T>;
