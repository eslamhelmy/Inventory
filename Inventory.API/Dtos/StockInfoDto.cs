using Inventory.Domain;

namespace Inventory.API.Dtos
{
    public class StockInfoDto
    {
        public ProductStatus Status { get; set; }
        public int Count { get; set; }
    }
}
