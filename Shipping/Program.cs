using System;

namespace Shipping
{
    using System.Threading.Tasks;

    using NServiceBus;

    internal class Program
    {
        private static async Task Main() {
            Console.Title = "Shipping";

            var endpointConfiguration = new EndpointConfiguration("Shipping");
            endpointConfiguration.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadKey();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}
