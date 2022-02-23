using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Entity;

namespace OA.Repository
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DepartmentRepository : BaseRepository<Department, int>, IDepartmentRepository
    {
        public DepartmentRepository(OaDbContext db)
        {
            this.db = db;
        }
    }
}
