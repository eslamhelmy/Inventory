using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Base
{
    public class BaseDomainEvent
    {
        public BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }

        public Guid EventId { get; init; }
        public DateTime CreatedOn { get; init; }
    }
}
