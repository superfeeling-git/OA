using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Dtos
{
    public class BaseDto
    {
        public int Id { get; set; }
        public int CreateId { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int? LastModifyId { get; set; }
        public string LastModifyName { get; set; }
        public DateTime? LastModifyTime { get; set; }
    }
}
