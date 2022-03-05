using OA.Dtos.Department;
using OA.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Dtos.UserAccount
{
    public class UserAccountDto : BaseDto
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public DepartmentDto DepartmentDto { get; set; }
        public int DepartmentId { get; set; }
        public string Tel { get; set; }
        public Status Status { get; set; }
        public int LoginAccount { get; set; }
        public int LoginLockAccount { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string LastLoginIp { get; set; }
    }
}
