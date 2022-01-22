using Inventory.API.Dtos;
using Inventory.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger
            , ProductService service)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPut("sell")]
        public async Task<IActionResult> SellProduct([FromBody] SellProductDto sellProductDto)
        {
            var result = await _service.SellProduct(sellProductDto);
            return Ok(result);
        }

    }
}
