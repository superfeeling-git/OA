using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;
using OA.Dtos;

namespace OA.Service
{
    public class TreeService<TDto,TEntity>
        where TDto : class, new()
    {
        private IMapper mapper;
        private List<TDto> ListDtos = new List<TDto>();
        private List<TEntity> entities = new List<TEntity>();

        public TreeService(IMapper mapper, List<TEntity> entities)
        {
            this.mapper = mapper;
            this.entities = entities;
        }

        public List<TDto> GetRecursionForList()
        {
            var list = entities.Where(m => (m as dynamic).ParentId == 0);

            foreach (var item in list)
            {
                var dto = mapper.Map<TDto>(item);

                GetSubNodeForList(dto);

                //递归
                ListDtos.Add(dto);
            }

            return ListDtos;
        }

        public void GetSubNodeForList(TDto dto)
        {
            var type = dto.GetType();

            var id = (int)type.GetProperties().Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(PrimaryKeyAttribute))).First().GetValue(dto);            

            var list = entities.Where(m => (m as dynamic).ParentId == id);
            foreach (var item in list)
            {
                var deptDto = mapper.Map<TDto>(item);

                var children = type.GetProperty("children").GetValue(dto) as List<TDto>;

                children.Add(deptDto);

                GetSubNodeForList(deptDto);
            }
        }
    }
}
