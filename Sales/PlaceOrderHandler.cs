using Messages;
using NServiceBus.Logging;

namespace Sales;

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
    public static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        log.Info($"Received PlaceOrder, Order ID: {message.OrderId}");

        var order = new OrderPlaced()
        {
            OrderId = message.OrderId,
        };

        context.Publish(order)
            .ConfigureAwait(false);

        return Task.CompletedTask;
    }
}