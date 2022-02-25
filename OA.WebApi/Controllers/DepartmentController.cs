﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Service;
using OA.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OA.Dtos.Department;
using Microsoft.Extensions.Logging;

namespace OA.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]    
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _DepartmentService;
        private ILogger<DepartmentController> _logger;

        public DepartmentController(
            IDepartmentService DepartmentService,
            ILogger<DepartmentController> logger
            )
        {
            this._DepartmentService = DepartmentService;
            this._logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentDto department)
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