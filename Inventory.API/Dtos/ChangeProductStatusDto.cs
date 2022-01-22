using Inventory.Domain;

namespace Inventory.API.Dtos
{
    public class ChangeProductStatusDto
    {
        public int ProductId { get; set; }
        public ProductStatus Status { get; set; }
    }
}
