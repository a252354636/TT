using EFFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFFramework.Service
{
    public interface IBaseService
    {
        void Add<T>(T entity) where T : IBaseEntity;
        void Commit();
        T GetModel<T>(Expression<Func<T, bool>> filter) where T : IBaseEntity;
        IQueryable<T> GetListByPage<T, TKey>(ref int Count, int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, bool isAscOrDesc) where T : IBaseEntity;
    }
}
