using Microsoft.AspNetCore.Mvc;
using OA.Dtos.UserAccount;
using OA.Service;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            this.userAccountService = userAccountService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Login(LoginDto loginDto)
        {
            return Ok(userAccountService.Login(loginDto));
        }
    }
}
