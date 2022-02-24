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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentDto department)
        {
            await _DepartmentService.CreateAsync(new Department 
            {
                DeptName = department.DeptName,
                DeptManageName = department.DeptManageName,
                Remark = department.Remark
            });
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(DepartmentDto department)
        {
            _DepartmentService.Create(department);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var list = await _DepartmentService.GetRecursion();
            return new JsonResult(list);
        }
    }
}