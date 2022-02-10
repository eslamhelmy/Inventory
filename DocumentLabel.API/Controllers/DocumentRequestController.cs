using DocumentLabel.API.Dtos;
using DocumentLabel.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentRequestController : ControllerBase
    {
        private readonly DocumentRequestService _service;
        private readonly ILogger<DocumentRequestController> _logger;

        public DocumentRequestController(ILogger<DocumentRequestController> logger
            , DocumentRequestService service)
        {
            _service = service;
            _logger = logger;
        }
        

        [HttpPost]
        public async Task<IActionResult> AddDocumentRequest([FromBody] AddDocumentRequestViewModel viewModel)
        {
            var result = await _service.AddDocumentRequest(viewModel);
            return Ok(result);
        }

    }
}
