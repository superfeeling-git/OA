using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public interface IBaseService<TEntity, TDto, TKey>
        where TEntity : class, new()
        where TDto : class, new()
        where TKey : struct
    {
        int Create(TDto dto);
        Task CreateAsync(TDto dto);
        int Delete(Expression<Func<TEntity, bool>> Condition);
        int Delete(TKey key);
        int Delete(TKey[] keys);
        Task<int> DeleteAsync(TKey key);
        TDto GetEntity(Expression<Func<TEntity, bool>> Condition);
        TDto GetEntity(TKey key);
        List<TDto> GetList(Expression<Func<TEntity, bool>> Condition = null);
        Task<List<TDto>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null);
        bool Update(TEntity entity);
    }
}
