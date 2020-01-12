using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using DokanyApp.Core.Models;

namespace DokanyApp.Infrastructure.Orders
{
    class OrderContext : DbContext
    {
        public OrderContext()
        {

        }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ShippingDate).HasColumnType("datetime");

                entity.Property(e => e.ShoppingCartIid).HasColumnName("ShoppingCartIId");

                entity.Property(e => e.OrderingStatus)
                    .HasMaxLength(50)
                    .HasConversion(x => x.ToString(), // to converter
                    x => (OrderStatusENU)Enum.Parse(typeof(OrderStatusENU), x));

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CustomerOrder");

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShippingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_ShippingInfo");

                entity.HasOne(d => d.ShoppingCartI)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShoppingCartIid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_ShoppingCart1");
            });
        }
        public virtual DbSet<Order> Orders { get; set; }
    }
}

