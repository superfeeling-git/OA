using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OA.Repository;
using OA.Entity;
using OA.Dtos.Department;
using AutoMapper;

namespace OA.Service
{
    public class DepartmentService : BaseService<Department,DepartmentDto, int>, IDepartmentService
    {
        private IDepartmentRepository DepartmentRepository;


        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            this.BaseRepository = departmentRepository;
            this.DepartmentRepository = departmentRepository;
            this.mapper = mapper;
        }
        
        public async Task<List<TreeDto>> GetRecursion()
        {
            var list = await DepartmentRepository.GetListAsync();
            TreeService<TreeDto, Department> treeService = new TreeService<TreeDto, Department>(mapper, list);
            return treeService.GetRecursionForList();
        }

        public async Task<List<DepartmentDto>> GetList()
        {
            var list = await DepartmentRepository.GetListAsync();
            TreeService<DepartmentDto, Department> treeService = new TreeService<DepartmentDto, Department>(mapper, list);
            return treeService.GetRecursionForList();
        }
    }
}