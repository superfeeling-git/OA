using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using OA.Entity;
using System.Threading.Tasks;
using Z.BulkOperations;
using Z.EntityFramework;
using Z.EntityFramework.Plus;
using Z.EntityFramework.Extensions;
using Z.EntityFramework.Extensions.EFCore;

namespace OA.Repository
{
    /// <summary>
    /// 抽象基类  where泛型约束,class：必须是引用类型
    /// </summary>
    /// <typeparam name="TEntity">类型</typeparam>
    /// <typeparam name="TKey">主键</typeparam>
    public abstract class BaseRepository<TEntity, TKey>
        where TEntity : class, new()
        where TKey : struct
    {
        protected OaDbContext db;

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            return db.SaveChanges();
        }

        #region MyRegion

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().SingleInsertAsync(entity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual bool Update(TEntity entity)
        {
            try
            {
                db.Set<TEntity>().SingleUpdate(entity);
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual int Delete(TKey key)
        {
            return db.Set<TEntity>().DeleteByKey(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<int> DeleteAsync(TKey key)
        {
            return await db.Set<TEntity>().DeleteByKeyAsync(key);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual int Delete(TKey[] keys)
        {
            return db.Set<TEntity>().DeleteByKey(keys);
        }

        /// <summary>
        /// 根据条件批量删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual int Delete(Expression<Func<TEntity, bool>> Condition)
        {
            return db.Set<TEntity>().Where(Condition).DeleteFromQuery();
        }

        /// <summary>
        /// 查单条实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual TEntity GetEntity(TKey key)
        {
            return db.Set<TEntity>().Find(key);
        }

        /// <summary>
        /// 根据条件获取单条实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> Condition)
        {
            return db.Set<TEntity>().FirstOrDefault(Condition);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = db.Set<TEntity>().AsQueryable();
            if(Condition != null)
            {
                list = list.Where(Condition);
            }
            return list.ToList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="Condition"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> Condition = null)
        {
            var list = db.Set<TEntity>().AsQueryable();
            if (Condition != null)
            {
                list = list.Where(Condition);
            }
            return await list.ToListAsync();
        }
        #endregion

    }
}
