using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Acme.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Where(Expression<Func<T, Boolean>> predicate);
        T FirstOrDefault(Expression<Func<T, Boolean>> predicate);
        Int32 Count(Expression<Func<T, Boolean>> predicate);
        Int32 Count();
        Int32 CountRaw(String query);
        IQueryable<T> GetAll();
        void Store(Object value);
        void Store(T value);
        Int32 SaveChanges();
        void Delete(Object value);
        void Delete(T value);
        T GetById(Object id);
        ICollection<T> RawQuery(String query);
    }
}
