
using DocumentLabel.Domain.Base;
using MediatR;

namespace Inventory.API.Mediatr
{
    public class DomainEventNotification<T> : INotification where T : BaseDomainEvent
    {
        public T DomainEvent { get; }

        public DomainEventNotification(T domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
