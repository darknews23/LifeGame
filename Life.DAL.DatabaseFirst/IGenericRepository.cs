using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Life.DAL.DatabaseFirst
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T item);
        void Create(List<T> items);
        T FindById(int id);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> predicate);
        void Remove(T item);
        void Update(T item);

        IEnumerable<T> GetWithInclude(Func<T, bool> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> GetWithInclude(params Expression<Func<T, object>>[] includeProperties);

    }
}
