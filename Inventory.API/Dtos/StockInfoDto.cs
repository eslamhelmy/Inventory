using Inventory.Domain;

namespace Inventory.API.Dtos
{
    public class InventoryDto
    {
        public ProductStatus Status { get; set; }
        public int Count { get; set; }
        public string StatusName { get; internal set; }
    }
}
