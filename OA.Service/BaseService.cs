using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OA.Service;
using OA.Repository;
using AutoMapper;

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
            return mapper.Map<TDto>(BaseRepository.GetEntity(Condition));
        }

        public virtual TDto GetEntity(TKey key)
        {
            return mapper.Map<TDto>(BaseRepository.GetEntity(key));
        }

        public virtual List<TDto> GetList(Expression<Func<TEntity, bool>> Condition = null)
        {
            return mapper.Map<List<TDto>>(BaseRepository.GetList(Condition));
        }

        public virtual async Task<List<TDto>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            return mapper.Map<List<TDto>>(await BaseRepository.GetListAsync(Condition));
        }

        public virtual bool Update(TEntity entity)
        {
            return BaseRepository.Update(entity);
        }
    }
}
