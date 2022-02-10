using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain.Base
{
    public abstract class Entity<TKey> : BaseEntity
    {
            public TKey Id { get; set; }
    }
}
