using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoBE.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderID);
                e.Property(o => o.CreateDate).HasDefaultValueSql("getutcdate()");

            });

            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetail");
                e.HasKey(o => new { o.OrderID, o.ProductID });
                e.HasOne(o => o.Order).WithMany(o=>o.OrderDetails).HasForeignKey(o=>o.OrderID).HasConstraintName("FK_OrderDetail_Order");
                e.HasOne(o => o.Product).WithMany(o=>o.OrderDetails).HasForeignKey(o=>o.ProductID).HasConstraintName("FK_OrderDetail_Product");
            });
        }
    }
}
