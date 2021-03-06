
using DocumentLabel.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain.Dispatcher
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent @event);
    }
}
