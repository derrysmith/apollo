using DerrySmith.Core.Domain.Features;
using MR = global::MediatR;

namespace DerrySmith.Core.Domain.MediatR.Features;

public class MrCommand<TFeatureCommand> : MR.IRequest
where TFeatureCommand : IFeatureCommand
{
	public MrCommand(TFeatureCommand command)
	{
		this.Command = command;
	}

	public TFeatureCommand Command { get; }
}

public class MrRequest<T> : MR.IRequest<T>
{
	public MrRequest(IFeatureRequest<T> request)
	{
		this.Request = request;
	}

	public IFeatureRequest<T> Request { get; }
}

public abstract class MrCommandHandler<TFeatureCommand> : MR.IRequestHandler<MrCommand<TFeatureCommand>>
	where TFeatureCommand : IFeatureCommand
{
	private MR.IMediator _mediator;
	
	protected abstract Task HandleAsync(TFeatureCommand command, CancellationToken ct);
	
	Task MR.IRequestHandler<MrCommand<TFeatureCommand>>.Handle(MrCommand<TFeatureCommand> request, CancellationToken cancellationToken)
	{
		return this.HandleAsync(request.Command, cancellationToken);
	}
}

public class MrMediator : IFeatureCommandSender, IFeatureRequestSender
{
	private readonly MR.IMediator _mediator;

	public MrMediator(MR.IMediator mediator)
	{
		_mediator = mediator;
	}

	public Task SendAsync<TFeatureCommand>(TFeatureCommand command, CancellationToken ct = default)
		where TFeatureCommand : IFeatureCommand
	{
		// wrap command in message
		var message = new MrCommand<TFeatureCommand>(command);
		
		// send
		return _mediator.Send(message, ct);
	}

	public Task<T> SendAsync<T>(IFeatureRequest<T> request, CancellationToken ct = default)
	{
		// wrap request in message
		var message = new MrRequest<T>(request);
		
		// send
		return _mediator.Send(message, ct);
	}
}