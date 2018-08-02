namespace Shipping {
    using System.Threading.Tasks;

    using Messages;

    using NServiceBus;
    using NServiceBus.Logging;

    public class OrderBilledHandler : IHandleMessages<OrderBilled> {
        private static readonly ILog log = LogManager.GetLogger<OrderPlacedHandler>();

        public Task Handle(OrderBilled message, IMessageHandlerContext context) {
            log.Info($"Received OrderBilled, OrderId = {message.OrderId} - Shipping now!");
            return Task.CompletedTask;
        }
    }
}