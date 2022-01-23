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
           // private readonly ApplicationDbContext _db;
            private readonly ILogger<Handler> _log;

            public Handler(ILogger<Handler> log)
            {
               // _db = db;
                _log = log;
            }

            public Task Handle(DomainEventNotification<OnStatusChangedEvent> notification, CancellationToken cancellationToken)
            {
                var domainEvent = notification.DomainEvent;
                try
                {
                    _log.LogDebug("Handling Domain Event. ProductId: {productId}  Type: {type}", domainEvent.ProductId, notification.GetType());
                    //from here you could 
                    // - create/modify entities within the same transaction as the backlogItem commit
                    // - trigger the publishing of an integration event on a servicebus (don't write it directly though, you need an outbox scoped to this transaction)

                    //Remember NOT to call SaveChanges on dbcontext if making db changes when handling DomainEvents
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
