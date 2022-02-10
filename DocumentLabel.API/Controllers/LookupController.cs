using DocumentLabel.API.Dtos;
using DocumentLabel.API.Services;
using DocumentLabel.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly LookupService _service;
        private readonly ILogger<LookupController> _logger;

        public LookupController(ILogger<LookupController> logger
            , LookupService service)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("tags")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetTags()
        {
            var test = User;
            var result = await _service.Get(LookupTypeEnum.Tag, LanguageEnum.English);
            return Ok(result);
        }

        [HttpGet("document-types")]
        public async Task<IActionResult> GetDocumentTypes()
        {
            var result = await _service.Get(LookupTypeEnum.DocumentRequestType, LanguageEnum.English);
            return Ok(result);
        }

    }
}
