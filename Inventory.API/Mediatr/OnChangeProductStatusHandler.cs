using Inventory.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.API.Mediatr
{
    public class OnChangeProductStatusHandler
    {
        public class Handler : INotificationHandler<DomainEventNotification<OnStatusChangedEvent>>
        {
            private readonly ILogger<Handler> _log;

            public Handler(ILogger<Handler> log)
            {
                _log = log;
            }

            public Task Handle(DomainEventNotification<OnStatusChangedEvent> notification, CancellationToken cancellationToken)
            {
                var domainEvent = notification.DomainEvent;
                try
                {
                    _log.LogDebug("Handling Domain Event. ProductId: {productId}  Type: {type}", domainEvent.ProductId, notification.GetType());
                    return Task.CompletedTask;
                }
                catch (Exception exc)
                {
                    _log.LogError(exc, "Error handling domain event {domainEvent}", domainEvent.GetType());
                    throw;
                }
            }
        }

    }
}
