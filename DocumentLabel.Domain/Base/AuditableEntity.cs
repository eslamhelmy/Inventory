using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLabel.Domain.Base
{
    public abstract class AuditableEntity<T> : Entity<T>
    {
            public int CreatedBy { get; set; }
            public DateTime CreatedAt { get; set; }
            public int ModifiedBy { get; set; }
            public DateTime ModifiedAt { get; set; }
    }
}
