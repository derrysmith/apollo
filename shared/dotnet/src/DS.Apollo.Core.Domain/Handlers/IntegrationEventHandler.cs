using DS.Apollo.Core.Domain.Messages;
using MassTransit;

namespace DS.Apollo.Core.Domain.Handlers;

public abstract class IntegrationEventHandler<T> : MassTransit.IConsumer<T>
	where T : class
{
	Task IConsumer<T>.Consume(ConsumeContext<T> context)
	{
		return this.ConsumeAsync(context.Message, context.CancellationToken);
	}

	protected abstract Task ConsumeAsync(T integrationEvent, CancellationToken cancellationToken = default);
}