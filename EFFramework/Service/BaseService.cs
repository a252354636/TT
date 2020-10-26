using EFFramework.Models;
using EFFramework.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFFramework.Service
{
    public class BaseService : IBaseService
    {
        public UnitOfWorkContext uw;
        public BaseService()
        {
            uw = new UnitOfWorkContext();
        }
        public void Add<T>(T entity) where T : IBaseEntity
        {
            uw.Add(entity);
        }
        public void Update<T>(T model) where T : IBaseEntity
        {
            uw.Update<T>(model);
        }
        public void Commit()
        {
            uw.Commit();
        }
        public IQueryable<T> GetListByPage<T, TKey>(ref int Count, int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAscOrDesc) where T : IBaseEntity
        {
            return uw.QueryReporitory().GetListByPage<T,TKey>(ref Count, pageIndex, pageSize, whereLambda, orderBy, isAscOrDesc);
        }

        public T GetModel<T>(Expression<Func<T, bool>> filter) where T : IBaseEntity
        {
            return uw.Repository<T>().GetModel(filter);
        }
        public List<TKey> GetSqlQuery<T, TKey>(string sql, params object[] parameters) where T : IBaseEntity
        {
            return uw.QueryReporitory().GetSqlQuery<TKey>(sql, parameters);
        }

    }
}