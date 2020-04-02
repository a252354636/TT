using EFFramework.Models;
using EFFramework.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EFFramework.UnitOfWork
{
    public class UnitOfWorkContext : IDisposable
    {
        private BaseDbContext readContext;
        private BaseDbContext writeContext;
        private bool disposed;
        private Dictionary<string, object> repositories;
    
        private void GetReadContext()
        {
            if (readContext == null)
                readContext = new BaseDbContext();
        }
        private void GetWriteContext()
        {
            if (writeContext == null)
                writeContext = new BaseDbContext();
        }
        private Repository<T> Repository<T>() where T : IBaseEntity
        {
            GetWriteContext();
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), writeContext);
                repositories.Add(type, repositoryInstance);
            }
            return (Repository<T>)repositories[type];
        }

        private QueryReporitory QueryReporitory()
        {
            GetReadContext();
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }
            var repositoryType = typeof(QueryReporitory);
            var type = repositoryType.Name;
            if (!repositories.ContainsKey(type))
            {
       
                var repositoryInstance = Activator.CreateInstance(repositoryType, readContext);
                repositories.Add(type, repositoryInstance);
            }
            return (QueryReporitory)repositories[type];
        }
        public void Add<T>(T entity) where T : IBaseEntity
        {
            var rep = this.Repository<T>();
            rep.Add(entity);
        }
        /// <summary>
        /// 单个对象修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update<T>(T model) where T : IBaseEntity
        {
            var rep = this.Repository<T>();
            rep.Update(model);
        }
        public void Commit()
        {
            GetWriteContext();
            writeContext.SaveChanges();
        }
        public T GetModel<T>(Expression<Func<T, bool>> filter) where T : IBaseEntity
        {
            var rep = this.Repository<T>();
            return rep.GetModel(filter);
        }
        public List<TKey> GetSqlQuery<T,TKey>(string sql, params object[] parameters) where T : IBaseEntity
        {
            return this.QueryReporitory().GetSqlQuery<TKey>(sql, parameters);
        }

        public IQueryable<T> GetListByPage<T, TKey>(ref int count, int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAscOrDesc) where T : IBaseEntity
        {
            return QueryReporitory().GetListByPage<T, TKey>(ref count, pageIndex, pageSize, whereLambda, orderBy, isAscOrDesc);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    readContext.Dispose();
                    writeContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
