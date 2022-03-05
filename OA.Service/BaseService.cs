using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OA.Service;
using OA.Repository;
using AutoMapper;
using System.Reflection;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace OA.Service
{
    public class BaseService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TDto : class, new()
        where TKey : struct
    {
        protected IBaseRepository<TEntity, TKey> BaseRepository;
        protected IMapper mapper;

        public virtual int Create(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            return BaseRepository.Create(entity);
        }

        public virtual async Task CreateAsync(TDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            await BaseRepository.CreateAsync(entity);
        }

        public virtual int Delete(Expression<Func<TEntity, bool>> Condition)
        {
            return BaseRepository.Delete(Condition);
        }

        public virtual int Delete(TKey key)
        {
            return BaseRepository.Delete(key);
        }

        public virtual int Delete(TKey[] keys)
        {
            return BaseRepository.Delete(keys);
        }

        public virtual async Task<int> DeleteAsync(TKey key)
        {
            return await BaseRepository.DeleteAsync(key);
        }

        public virtual TDto GetEntity(Expression<Func<TEntity, bool>> Condition)
        {
            var entity = BaseRepository.GetEntity(Condition);
            return mapper.Map<TDto>(entity);
        }

        public virtual TDto GetEntity(TKey key)
        {
            var entity = BaseRepository.GetEntity(key);
            return mapper.Map<TDto>(entity);
        }

        public virtual List<TDto> GetList(Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = BaseRepository.GetList(Condition);
            return mapper.Map<List<TDto>>(list);
        }

        public virtual async Task<List<TDto>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = await BaseRepository.GetListAsync(Condition);
            return mapper.Map<List<TDto>>(list);
        }

        public virtual bool Update(TDto dto)
        {
            //从数据库先查实体
            Type type = dto.GetType();

            var props = type.GetProperties();

            var primaryKey = props.First(m => m.GetCustomAttributes(typeof(KeyAttribute)).Count() > 0);

            var id = primaryKey.GetValue(dto);

            var db_entity = BaseRepository.GetEntity((TKey)id);

            //实体所有属性
            var entityprops = db_entity.GetType().GetProperties();

            foreach (var item in entityprops)
            {
                if (props.Any(m => m.Name == item.Name))
                {
                    var currProp = props.First(m => m.Name == item.Name);
                    item.SetValue(db_entity, currProp.GetValue(dto));
                }
            }

            db_entity.GetType().GetProperty("LastModifyId").SetValue(db_entity, 0);

            db_entity.GetType().GetProperty("LastModifyTime").SetValue(db_entity, DateTime.Now);

            //遍历entity实体属体，给数据库赋值
            return BaseRepository.Update(db_entity);
        }
    }
}
