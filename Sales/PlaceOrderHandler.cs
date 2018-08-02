﻿namespace Sales {
    using System.Threading.Tasks;

    using Messages;

    using NServiceBus;
    using NServiceBus.Logging;

    public class PlaceOrderHandler : IHandleMessages<PlaceOrder> {
        private static readonly ILog log = LogManager.GetLogger<PlaceOrderHandler>();

        public Task Handle(PlaceOrder message, IMessageHandlerContext context) {
            log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");
            return Task.CompletedTask;
        }
    }
}