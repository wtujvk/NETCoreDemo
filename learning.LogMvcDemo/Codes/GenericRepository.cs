using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using learning.LogMvcDemo.Codes.Entitys;

namespace learning.LogMvcDemo.Codes
{
    /// <summary>
    /// 泛型仓储。
    /// </summary>
    public class GenericRepository<T> where T : class, IEntity, new()
    {
        internal AppDataContext Context;
        internal DbSet<T> Dbset;

        public GenericRepository(AppDataContext context)
        {
            this.Context = context;
            this.Dbset = context.Set<T>();
        }

        /// <summary>
        /// 添加。
        /// </summary>
        /// <param name="t">实体。</param>
        public void Insert(T t)
        {
            Dbset.Add(t);
        }

        /// <summary>
        /// 获取延迟结果集。
        /// </summary>
        /// <param name="expression">表达式。</param>
        /// <returns>结果集。</returns>
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Dbset.Where(expression);
        }

        /// <summary>
        /// 更新。
        /// </summary>
        /// <param name="expression">条件。</param>
        /// <param name="updateExpression">更新。</param>
        public void UpdateFromQuery(Expression<Func<T, bool>> expression, Expression<Func<T, T>> updateExpression)
        {
            Dbset.Where(expression).UpdateFromQuery(updateExpression);
        }

        /// <summary>
        /// 删除。
        /// </summary>
        /// <param name="expression">条件。</param>
        public void DeleteFromQuery(Expression<Func<T, bool>> expression)
        {
            Dbset.Where(expression).DeleteFromQuery();
        }

        /// <summary>
        /// 获取结果集。
        /// </summary>
        /// <typeparam name="TR">类型。</typeparam>
        /// <param name="expression">条件。</param>
        /// <param name="selector">投影。</param>
        /// <returns>结果集。</returns>
        public IQueryable<TR> GetSelect<TR>(Expression<Func<T, bool>> expression, Expression<Func<T, TR>> selector)
        {
            return Dbset.Where(expression).Select(selector);
        }
    }
}