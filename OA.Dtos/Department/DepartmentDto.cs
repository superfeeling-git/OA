using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public int ParentId { get; set; }
        public string DeptManageName { get; set; }
        public string Remark { get; set; }
        public List<DepartmentDto> children { get; set; }
    }
}
