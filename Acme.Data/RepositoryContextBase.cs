using System;
using System.Collections.Generic;
using System.Text;

namespace Acme.Data
{
    public abstract class RepositoryContextBase
    {
        public abstract IRepository<T> GetRepository<T>() where T : class;
        public virtual void InitializeDatabase() { }
        public virtual void DeleteDatabase() { }
    }
}
