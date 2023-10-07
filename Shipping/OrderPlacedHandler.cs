using Messages;
using NServiceBus.Logging;

namespace Shipping;

public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    public static ILog log = LogManager.GetLogger<OrderPlacedHandler>();
    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Shipping order for order ID: {message.Id}");

        return Task.CompletedTask;
    }
}