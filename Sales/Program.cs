using NServiceBus.Logging;

namespace Sales;

class Program
{

    private static ILog log = LogManager.GetLogger<Program>();

    static async Task Main()
    {
        Console.Title = "Sales";

        var endpointConfiguration = new EndpointConfiguration("Sales");

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var recoverability = endpointConfiguration.Recoverability();

        // Sets the number of times Immediate Retries are performed
        recoverability.Immediate(
            immediate =>
            {
                immediate.NumberOfRetries(5);
            });

        var transport = endpointConfiguration.UseTransport<LearningTransport>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration)
            .ConfigureAwait(false);

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();

        await endpointInstance.Stop().ConfigureAwait(false);
    }
}