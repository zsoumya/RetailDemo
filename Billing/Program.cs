namespace Billing {
    using System;
    using System.Threading.Tasks;

    using NServiceBus;

    internal class Program {
        private static async Task Main() {
            Console.Title = "Billing";

            var endpointConfiguration = new EndpointConfiguration("Billing");
            endpointConfiguration.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadKey();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}