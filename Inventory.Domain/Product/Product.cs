using Inventory.Domain.Base;

namespace Inventory.Domain
{
    public partial class Product: Entity<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public ProductStatus Status { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
