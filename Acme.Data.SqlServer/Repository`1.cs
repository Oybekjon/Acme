using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Acme.Data.SqlServer
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private DbContext Context;
        public Repository(DbContext context)
        {
            Guard.NotNull(context, "context");
            Context = context;
        }
        public IQueryable<T> Where(Expression<Func<T, Boolean>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public T FirstOrDefault(Expression<Func<T, Boolean>> predicate)
        {
            return Context.Set<T>().FirstOrDefault(predicate);
        }
        public Int32 Count(Expression<Func<T, Boolean>> predicate)
        {
            return Context.Set<T>().Count(predicate);
        }
        public Int32 Count()
        {
            return Context.Set<T>().Count();
        }
        public Int32 CountRaw(String query)
        {
            throw new NotSupportedException();
        }
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public void Store(Object value)
        {
            throw new NotSupportedException();
        }
        public void Store(T value)
        {
            Guard.NotNull(value, "value");
            if (Context.Entry(value).State == EntityState.Detached)
                Context.Set<T>().Add(value);
        }
        public Int32 SaveChanges()
        {
            return Context.SaveChanges();
        }
        public void Delete(Object value)
        {
            throw new NotSupportedException();
        }
        public void Delete(T value)
        {
            Guard.NotNull(value, "value");
            if (Context.Entry(value).State != EntityState.Deleted)
                Context.Set<T>().Remove(value);
        }
        public T GetById(Object id)
        {
            
            throw new NotSupportedException("This operation is not supported in this implementation of the repository");
        }
        public ICollection<T> RawQuery(String query)
        {
            throw new NotSupportedException();
        }
    }
}
