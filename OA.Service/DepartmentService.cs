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
        private ITreeService treeService;

        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper, ITreeService treeService)
        {
            this.BaseRepository = departmentRepository;
            this.DepartmentRepository = departmentRepository;
            this.mapper = mapper;
            this.treeService = treeService;
        }
        
        public async Task<List<TreeDto>> GetRecursion()
        {
            return treeService.GetRecursionForList<Department, TreeDto>(await DepartmentRepository.GetListAsync());
        }

        public async Task<List<DepartmentDto>> GetList()
        {
            return treeService.GetRecursionForList<Department, DepartmentDto>(await DepartmentRepository.GetListAsync());
        }
    }
}