using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Repository;
using OA.Entity;
using System.Threading.Tasks;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentRepository _DepartmentRepository;
        public DepartmentController(IDepartmentRepository DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Department department)
        {
            await _DepartmentRepository.CreateAsync(department);
            return Ok();
        }
    }
}
