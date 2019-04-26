using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyImages.Repositories
{
    interface IRepository<T> : IDisposable
    {
        void Commit();
        void Edit(T Entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(string id);
        void Remove(T Entity);
        void Add(T Entity);
        void Dispose();
    }
}
