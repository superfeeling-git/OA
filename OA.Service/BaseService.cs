using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OA.Service;
using OA.Repository;

namespace OA.Service
{
    public class BaseService<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        protected IBaseRepository<TEntity, TKey> BaseRepository;

        public virtual int Create(TEntity entity)
        {
            return BaseRepository.Create(entity);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
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

        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> Condition)
        {
            return BaseRepository.GetEntity(Condition);
        }

        public virtual TEntity GetEntity(TKey key)
        {
            return BaseRepository.GetEntity(key);
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> Condition = null)
        {
            return BaseRepository.GetList(Condition);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            return await BaseRepository.GetListAsync(Condition);
        }

        public virtual bool Update(TEntity entity)
        {
            return BaseRepository.Update(entity);
        }
    }
}
