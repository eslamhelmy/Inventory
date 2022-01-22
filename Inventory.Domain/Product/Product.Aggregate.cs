using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain
{
    public partial class Product
    {
        public Product()
        {

        }
        public Product(string name, string barcode, string description, decimal weight, ProductStatus status, int categoryId):this()
        {
            Update(name, barcode, description, weight, status, categoryId);
        }

        public void Update(string name,
            string barcode,
            string description,
            decimal weight,
            ProductStatus status,
            int categoryId)
        {
            Name = name;
            Barcode = barcode;
            Description = description;
            Weight = weight;
            Status = status;
            CategoryId = categoryId;
        }

        public bool ChangeStatus(ProductStatus status)
        {
            //Add Event 
            this.AddEvent(new OnStatusChangedEvent
            {
                NewStatus = status,
                OldStatus = this.Status,
                ProductId = this.Id
            });

            Status = status;
            return true;
        }

        public bool Sell()
        {
            // u can sell product if it is in stock only
            if(this.Status == ProductStatus.InStock)
            {
                this.ChangeStatus(ProductStatus.Sold);  
                return true;
            }
            return false;

        }

    }
}
