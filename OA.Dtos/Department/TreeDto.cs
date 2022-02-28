using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Dtos.Department
{
    /// <summary>
    /// 树，自包含
    /// </summary>
    public class TreeDto
    {
        [PrimaryKey]
        public int value { get; set; }
        public string label { get; set; }
        public List<TreeDto> children { get; set; } = new List<TreeDto>();
    }
}
