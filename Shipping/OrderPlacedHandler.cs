namespace Shipping {
    using System.Threading.Tasks;

    using Messages;

    using NServiceBus;
    using NServiceBus.Logging;

    public class OrderPlacedHandler : IHandleMessages<OrderPlaced> {
        private static readonly ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderPlaced message, IMessageHandlerContext context) {
            log.Info($"Received OrderPlaced, OrderId = {message.OrderId} - Preparing for shipment");
            return Task.CompletedTask;
        }
    }
}