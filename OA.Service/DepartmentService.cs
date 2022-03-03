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
        private ITreeService TreeService;

        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper, ITreeService TreeService)
        {
            this.BaseRepository = departmentRepository;
            this.DepartmentRepository = departmentRepository;
            this.mapper = mapper;
            this.TreeService = TreeService;
        }

        public async Task<List<TreeDto>> GetTreeNodesAsync()
        {
            return TreeService.GetRecursionForList<Department, TreeDto>(await DepartmentRepository.GetListAsync());
        }

        public async Task<List<DepartmentDto>> GetTableDataAsync()
        {
            return TreeService.GetRecursionForList<Department, DepartmentDto>(await DepartmentRepository.GetListAsync());
        }
    }
}