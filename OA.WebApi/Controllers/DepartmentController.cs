using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OA.Dtos.Department;
using Microsoft.Extensions.Logging;
using OA.Service.Test;
using System.Threading;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _DepartmentService;
        private ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService DepartmentService,
            ILogger<DepartmentController> logger)
        {
            this._DepartmentService = DepartmentService;
            this._logger = logger;
        }

        /// <summary>
        /// 添加部门
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentDto department)
        {
            new Thread(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    _logger.LogInformation(i.ToString());
                }
            }).Start();
            
            await _DepartmentService.CreateAsync(department);
            return Ok();
        }

        /// <summary>
        /// 获取所有递归节点
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTreeNodesAsync()
        {
            var list = await _DepartmentService.GetTreeNodesAsync();
            return new JsonResult(list);
        }

        /// <summary>
        /// 获取数据表格递归的数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTableDataAsync()
        {
            return new JsonResult(await _DepartmentService.GetTableDataAsync());
        }

        [HttpGet]
        public IActionResult GetDepartment(int id)
        {
            return Ok(_DepartmentService.GetEntity(id));
        }

        [HttpPost]
        public IActionResult Update(DepartmentDto department)
        {
            return Ok(_DepartmentService.Update(department));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Ok(_DepartmentService.Delete(id));
        }
    }
}