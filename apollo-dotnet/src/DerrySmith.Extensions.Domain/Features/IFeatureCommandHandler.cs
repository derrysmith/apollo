namespace DerrySmith.Extensions.Domain.Features;

public interface IFeatureCommandHandler<TCmd>
	where TCmd : IFeatureCommand;
