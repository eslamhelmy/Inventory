using Inventory.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
       , IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }
       
    }
}
