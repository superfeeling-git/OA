using Microsoft.AspNetCore.Mvc;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        public IActionResult Create()
        {
            return Ok();
        }
    }
}
