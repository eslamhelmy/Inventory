using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Dtos
{
    public class SellProductDto
    {
        //I made product id as nullable so i can enforce the frontend to pass, otherwise the formatter will add it with default value zero
        [Required]
        public int? ProductId { get; set; }
    }
}
