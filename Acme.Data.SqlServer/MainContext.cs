using Acme.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Acme.Data.SqlServer
{
    public class MainContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public MainContext() { }
    }
}
