using Inventory.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public class OnStatusChangedEvent: BaseDomainEvent
    {
        public int ProductId { get; set; }
        public ProductStatus OldStatus { get; set; }
        public ProductStatus NewStatus { get; set; }
    }
}
