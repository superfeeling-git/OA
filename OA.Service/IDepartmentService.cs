using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Dtos.Department;
using OA.Entity;

namespace OA.Service
{
    public interface IDepartmentService : IBaseService<Department, DepartmentDto, int>
    {
        Task<List<TreeDto>> GetTreeNodesAsync();
        Task<List<DepartmentDto>> GetTableDataAsync();
    }
}
