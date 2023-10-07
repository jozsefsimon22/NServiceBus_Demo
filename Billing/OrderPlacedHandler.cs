using Billing.Messages;
using Messages;
using NServiceBus.Logging;

namespace Billing;

public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    public static ILog log = LogManager.GetLogger<OrderPlacedHandler>();

    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderPlaced, Order ID {message.OrderId}");

        var paymentReceived = new OrderBilled()
        {
            OrderId = message.OrderId
        };

        context.Publish(paymentReceived).ConfigureAwait(false);

        return Task.CompletedTask;
    }
}