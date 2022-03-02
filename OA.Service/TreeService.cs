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
    public class TreeService : ITreeService
    {
        private IMapper mapper;

        public TreeService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<TDto> GetRecursionForList<TEntity, TDto>(List<TEntity> entities)
        {
            List<TDto> ListDtos = new List<TDto>();

            var list = entities.Where(m => (m as dynamic).ParentId == 0);

            foreach (var item in list)
            {
                var dto = mapper.Map<TDto>(item);

                GetSubNodeForList(dto, entities);

                //递归
                ListDtos.Add(dto);
            }

            return ListDtos;
        }

        private void GetSubNodeForList<TEntity, TDto>(TDto dto, List<TEntity> entities)
        {
            var type = dto.GetType();

            var id = (int)type.GetProperties().Where(m => m.CustomAttributes.Any(a => a.AttributeType == typeof(PrimaryKeyAttribute))).First().GetValue(dto);

            var list = entities.Where(m => (m as dynamic).ParentId == id);
            foreach (var item in list)
            {
                var deptDto = mapper.Map<TDto>(item);

                var children = type.GetProperty("children").GetValue(dto) as List<TDto>;

                children.Add(deptDto);

                GetSubNodeForList(deptDto, entities);
            }
        }
    }
}