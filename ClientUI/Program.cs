using Messages;
using NServiceBus.Logging;

class Program
{

    static ILog log = LogManager.GetLogger<Program>();

    static async Task Main()
    {
        Console.Title = "ClientUI";

        var endpointConfiguration = new EndpointConfiguration("ClientUI");

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();
        var transport = endpointConfiguration.UseTransport<LearningTransport>();

        var routing = transport.Routing();
        routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        await RunLoop(endpointInstance)
            .ConfigureAwait(false);

        await endpointInstance.Stop()
            .ConfigureAwait(false);
    }


    static async Task RunLoop(IEndpointInstance endpointInstance)
    {
        while (true)
        {
            log.Info("To place a new order place 'P' or to quit press 'Q'\n");

            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.P:
                    var command = new PlaceOrder()
                    {
                        Id = Guid.Empty.ToString()
                    };

                    log.Info($"Sending new order; Order ID: {command.Id}");
                    await endpointInstance.SendLocal(command)
                        .ConfigureAwait(false);

                    break;

                case ConsoleKey.Q:
                    return;

                default: log.Info("Invalid key, try again.");
                    break;
            }
        }
    }
}