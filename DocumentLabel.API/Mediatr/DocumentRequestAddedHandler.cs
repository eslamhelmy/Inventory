using DocumentLabel.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Inventory.API.Mediatr
{
    public class DocumentRequestAddedHandler
    {
        public class Handler : INotificationHandler<DomainEventNotification<DocumentRequestAdded>>
        {
            private readonly ILogger<Handler> _log;

            public Handler(ILogger<Handler> log)
            {
                _log = log;
            }

            public Task Handle(DomainEventNotification<DocumentRequestAdded> notification, CancellationToken cancellationToken)
            {
                var domainEvent = notification.DomainEvent;
                try
                {
                    _log.LogDebug("Handling Domain Event. EventId: {EventId}  Type: {type}", domainEvent.EventId, notification.GetType());
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
