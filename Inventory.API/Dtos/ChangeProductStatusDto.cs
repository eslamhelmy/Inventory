using Inventory.Domain;
using System.ComponentModel.DataAnnotations;

namespace Inventory.API.Dtos
{
    public class ChangeProductStatusDto
    {
        //I made product id, status as nullable so i can enforce the frontend to pass, otherwise the formatter will add them with default value zero
        [Required]
        public int? ProductId { get; set; }
        [Required]
        [Range(0,2)]
        public ProductStatus? Status { get; set; }
    }
}
