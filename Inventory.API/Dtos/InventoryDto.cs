using Inventory.Domain;

namespace Inventory.API.Dtos
{
    public class InventoryDto
    {
        public string StatusName { get; internal set; }
        public ProductStatus Status { get; set; }
        public int Count { get; set; }
    }
}
