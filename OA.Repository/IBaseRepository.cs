using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OA.Repository
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class,new()
        where TKey : struct
    {
        int Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        int Delete(Expression<Func<TEntity, bool>> Condition);
        int Delete(TKey key);
        int Delete(TKey[] keys);
        Task<int> DeleteAsync(TKey key);
        TEntity GetEntity(Expression<Func<TEntity, bool>> Condition);
        TEntity GetEntity(TKey key);
        List<TEntity> GetList(Expression<Func<TEntity, bool>> Condition = null);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null);
        bool Update(TEntity entity);
    }
}