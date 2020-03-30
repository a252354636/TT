using EFFramework.DLog;
using EFFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFFramework.Repository
{
    public class QueryReporitory: IRepository 
    {
        private BaseDbContext uw;
        public QueryReporitory(BaseDbContext context)
        {
            this.uw = context;
        }
        public List<TM> GetSqlQuery<TM>(string sql, params object[] parameters)
        {
            return this.uw.Database.SqlQuery<TM>(sql, parameters).ToList();
        }
        /// <summary>
        /// 分页查询 
        /// </summary>
        /// <param name="pageCount">总页数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <param name="isAscOrDesc">正序（true）还是倒序(false)</param>
        /// <returns></returns>
        public IQueryable<T> GetListByPage<T,TKey>(ref int Count, int pageIndex, int pageSize, Expression<Func<T,bool>> whereLambda, Expression<Func<T,TKey>> orderBy, bool isAscOrDesc) where T : IBaseEntity
        {
            try
            {
                //根据条件获取总条数
                Count = uw.Set<T>().Where(whereLambda).Count();
                int pageCount = Math.Max((Count + pageSize - 1) / pageSize, 1);
                if (pageCount < pageIndex)
                {
                    pageIndex = pageIndex - 1;
                }
                //反回集合
                if (isAscOrDesc)
                {
                    return uw.Set<T>().Where(whereLambda).OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
                else
                {
                    return uw.Set<T>().Where(whereLambda).OrderByDescending(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return null;
            }
        }
    }
}
