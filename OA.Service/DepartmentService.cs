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

        private List<TreeDto> TreeDtos = new List<TreeDto>();

        public async Task<List<TreeDto>> GetRecursion()
        {
            var list = await DepartmentRepository.GetListAsync();

            foreach (var item in list.Where(m => m.ParentId == 0))
            {
                var subItem_1 = new TreeDto
                {
                    value = item.Id,
                    label = item.DeptName
                };

                GetSubNode(subItem_1, list);

                //递归
                TreeDtos.Add(subItem_1);
            }

            return TreeDtos;
        }

        public void GetSubNode(TreeDto dto, List<Department> dtos)
        {
            var list = dtos.Where(m => m.ParentId == dto.value);
            foreach (var item in list)
            {
                var subItem_2 = new TreeDto
                {
                    value = item.Id,
                    label = item.DeptName
                };
                dto.children.Add(subItem_2);

                GetSubNode(subItem_2, dtos);
            }
        }

        /// <summary>
        /// 获取所有嵌套的节点数据  递归
        /// </summary>
        /// <returns></returns>
        public async Task<List<TreeDto>> GetData()
        {
            var list = await DepartmentRepository.GetListAsync();

            foreach (var item in list.Where(m => m.ParentId == 0))
            {
                //家电--电视、冰箱、洗衣机
                var subItem_1 = new TreeDto
                {
                    value = item.Id,
                    label = item.DeptName
                };

                foreach (var sub in list.Where(m => m.ParentId == item.Id))
                {
                    var subItem_2 = new TreeDto
                    {
                        value = sub.Id,
                        label = sub.DeptName
                    };
                    subItem_1.children.Add(subItem_2);
                }

                TreeDtos.Add(subItem_1);
            }
            return TreeDtos;
        }
    }
}