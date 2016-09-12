using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DotaStore.Domain.Entities;

namespace DotaStore.Domain.Concrete
{
    public class DotaShopContext:DbContext
    {
        public DotaShopContext() : base("DotaStore")
        {
            
        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
