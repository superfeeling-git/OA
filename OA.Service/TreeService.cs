using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OA.Service
{
    public class TreeService : ITreeService
    {
        private IMapper mapper;

        public TreeService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        /// <summary>
        /// 泛型、反射、Automapper高级应用、递归     通用传入一个List<TEntity>，返回带有树结构的List<TDto>
        /// </summary>
        public List<TDto> GetRecursionForList<TEntity, TDto>(List<TEntity> entities)
        {
            List<TDto> ListDtos = new List<TDto>();

            foreach (var item in entities.Where(m => (m as dynamic).ParentId == 0))
            {
                var dto = mapper.Map<TDto>(item);

                GetSubNodeForList(dto, entities);

                //递归
                ListDtos.Add(dto);
            }

            return ListDtos;
        }


        private void GetSubNodeForList<TEntity, TDto>(TDto dto, List<TEntity> list)
        {
            var type = dto.GetType();

            //获取主键字段
            var parmaryKey = type.GetProperties().First(m => m.GetCustomAttributes(typeof(KeyAttribute), true).Length > 0);

            //通过父ID找到了所有子级节点，实体类型的节点
            var _list = list.Where(m => (m as dynamic).ParentId == (int)parmaryKey.GetValue(dto));

            foreach (var item in _list)
            {
                //执行成功  TreeDto{value,label}   Department{Id,DeptName}   //Automapper高级应用
                var deptDto = mapper.Map<TDto>(item);

                //(type.GetProperty("children").GetValue(dto) as List<TDto>).Add(deptDto);                

                (dto as dynamic).children.Add(deptDto);

                GetSubNodeForList(deptDto, list);
            }
        }
    }
}