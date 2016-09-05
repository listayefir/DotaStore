using DotaStore.Domain.Entities;

namespace DotaStore.Domain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DotaShop : DbContext
    {
        public DotaShop()
            : base("name=DotaShop")
        {
        }

        public virtual DbSet<Badge> Badges { get; set; }
        public virtual DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .Property(e => e.Price)
                .HasPrecision(2, 0);

            modelBuilder.Entity<Item>()
                .HasOptional(e => e.Badges)
                .WithRequired(e => e.Items);
        }
    }
}
