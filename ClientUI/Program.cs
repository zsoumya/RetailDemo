namespace ClientUI {
    using System;
    using System.Threading.Tasks;

    using Messages;

    using NServiceBus;
    using NServiceBus.Logging;

    internal class Program {
        private static readonly ILog log = LogManager.GetLogger<Program>();

        private static async Task Main(string[] args) {
            Console.Title = "ClientUI";
            var endpointConfiguration = new EndpointConfiguration("ClientUI");
            TransportExtensions<LearningTransport> transport = endpointConfiguration.UseTransport<LearningTransport>();

            RoutingSettings<LearningTransport> routing = transport.Routing();
            routing.RouteToEndpoint(typeof(PlaceOrder), "Sales");

            IEndpointInstance endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            await RunLoop(endpointInstance).ConfigureAwait(false);

            await endpointInstance.Stop().ConfigureAwait(false);
        }

        private static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                log.Info("Press 'P' to place an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.P:
                        // Instantiate the command
                        var command = new PlaceOrder
                        {
                            OrderId = Guid.NewGuid().ToString()
                        };

                        // Send the command to the local endpoint
                        log.Info($"Sending PlaceOrder command, OrderId = {command.OrderId}");
                        await endpointInstance.Send(command).ConfigureAwait(false);

                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        log.Info("Unknown input. Please try again.");
                        break;
                }
            }
        }
    }
}