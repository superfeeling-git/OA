using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OA.Dtos.Department;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]    
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService DepartmentService)
        {
            this._DepartmentService = DepartmentService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await _DepartmentService.GetListAsync();
            return new JsonResult(list);
        }
    }
}