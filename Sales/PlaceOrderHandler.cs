using Messages;
using NServiceBus.Logging;

namespace Sales;

public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
{
    public static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
    public Task Handle(PlaceOrder message, IMessageHandlerContext context)
    {
        log.Info($"Order received, order ID: {message.Id}");

        return Task.CompletedTask;
    }
}