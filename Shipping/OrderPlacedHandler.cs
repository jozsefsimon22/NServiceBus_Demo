using Messages;
using NServiceBus.Logging;

namespace Shipping;

public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    public static ILog log = LogManager.GetLogger<OrderPlacedHandler>();
    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderPlaced, Order ID: {message.OrderId}");

        return Task.CompletedTask;
    }
}