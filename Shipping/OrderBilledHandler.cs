using Billing.Messages;
using Messages;
using NServiceBus.Logging;

namespace Shipping;

public class OrderBilledHandler : IHandleMessages<OrderBilled>
{
    public static ILog log = LogManager.GetLogger<OrderBilledHandler>();
    public Task Handle(OrderBilled message, IMessageHandlerContext context)
    {
        log.Info($"Received OrderBilled, Order ID: {message.OrderId}");

        return Task.CompletedTask;
    }
}