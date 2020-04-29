using EFFramework.DLog;
using EFFramework.Models;
using EFFramework.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public Repository<T> Repository<T>() where T : IBaseEntity
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

        public QueryReporitory QueryReporitory()
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
        public void SaveChanges()
        {
            GetWriteContext();
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    writeContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    // Get the current entity values and the values in the database
                    var entry = ex.Entries.Single();
                    var currentValues = entry.CurrentValues;
                    var databaseValues = entry.GetDatabaseValues();

                    // Choose an initial set of resolved values. In this case we
                    // make the default be the values currently in the database.
                    var resolvedValues = databaseValues.Clone();

                    // Have the user choose what the resolved values should be
                    HaveUserResolveConcurrency(currentValues, databaseValues, resolvedValues);

                    // Update the original values with the database values and
                    // the current values with whatever the user choose.
                    entry.OriginalValues.SetValues(databaseValues);
                    entry.CurrentValues.SetValues(resolvedValues);
                  
                }
            } while (saveFailed);
        }
        public void HaveUserResolveConcurrency(DbPropertyValues currentValues,
                               DbPropertyValues databaseValues,
                               DbPropertyValues resolvedValues)
        {
            // Show the current, database, and resolved values to the user and have
            // them edit the resolved values to get the correct resolution.
            Log.Error("并发异常");
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
