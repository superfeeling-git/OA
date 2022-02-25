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
    public class DepartmentService : BaseService<Department, int>, IDepartmentService
    {
        private IDepartmentRepository DepartmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this.BaseRepository = departmentRepository;
            this.DepartmentRepository = departmentRepository;
        }

        private List<TreeDto> TreeDtos = new List<TreeDto>();
        public IMapper _mapper { get; set; }

        public int Create(DepartmentDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            List<Department> list = new List<Department> {
                new Department{ DeptName = "abc" }
            };

            var dtos = _mapper.Map<List<DepartmentDto>>(list);

            return 0;
        }

        public void Recursion(TreeDto dtos, List<Department> list)
        {
            foreach (var item in list.Where(m => m.ParentId == dtos.value))
            {
                var subItem_1 = new TreeDto
                {
                    value = item.Id,
                    label = item.DeptName
                };
                dtos.children.Add(subItem_1);
                Recursion(subItem_1, list);
            }
        }

        /// <summary>
        /// 获取所有嵌套的节点数据  递归
        /// </summary>
        /// <returns></returns>
        public async Task<List<TreeDto>> GetRecursion()        {

            var list = await DepartmentRepository.GetListAsync();

            foreach (var item in list.Where(m => m.ParentId == 0))
            {
                var subItem_1 = new TreeDto
                {
                    value = item.Id,
                    label = item.DeptName
                };

                Recursion(subItem_1, list);

                TreeDtos.Add(subItem_1);
            }
            return TreeDtos;
        }
    }
}