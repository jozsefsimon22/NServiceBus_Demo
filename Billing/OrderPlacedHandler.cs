using Messages;
using NServiceBus.Logging;

namespace Billing;

public class OrderPlacedHandler : IHandleMessages<OrderPlaced>
{
    public static ILog log = LogManager.GetLogger<OrderPlacedHandler>();
    public Task Handle(OrderPlaced message, IMessageHandlerContext context)
    {
        log.Info($"Charging bank account for order ID: {message.Id}");

        return Task.CompletedTask;
    }
}