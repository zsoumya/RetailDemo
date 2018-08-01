namespace Sales {
    using System;
    using System.Threading.Tasks;

    using NServiceBus;

    internal class Program {
        private static async Task Main() {
            Console.Title = "Sales";

            var endpointConfiguration = new EndpointConfiguration("Sales");
            endpointConfiguration.UseTransport<LearningTransport>();

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}