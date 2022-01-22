using Inventory.Domain.Base;
using System.Collections.Generic;

namespace Inventory.Domain
{
    public class Category: Entity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
