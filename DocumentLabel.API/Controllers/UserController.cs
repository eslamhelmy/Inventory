using DocumentLabel.API.Dtos;
using DocumentLabel.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Logging;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger
            , UserService service)
        {
            _service = service;
            _logger = logger;
        }
        

        [HttpPost]
        [Authorize(AuthenticationSchemes = IISDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Login()
        {
            IPrincipal user = HttpContext.User;
            var result = await _service.Login(user.Identity.Name);
            return Ok(result);
        }

    }
}
