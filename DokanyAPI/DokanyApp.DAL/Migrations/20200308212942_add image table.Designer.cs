﻿// <auto-generated />
using System;
using DokanyApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DokanyApp.DAL.Migrations
{
    [DbContext(typeof(EFUnitOfWork))]
    [Migration("20200308212942_add image table")]
    partial class addimagetable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DokanyApp.BLL.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<int>("ShoppingCartId");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("CartItemId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("DokanyApp.BLL.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DokanyApp.BLL.CreditCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardName");

                    b.Property<string>("CardNumber");

                    b.Property<int>("Month");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("DokanyApp.BLL.Entities.ImageProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ImageProduct");
                });

            modelBuilder.Entity("DokanyApp.BLL.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartItemIId")
                        .HasColumnName("CartItemIId");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("CreditCardId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("OrderingStatus")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PaymentMethod");

                    b.Property<decimal>("ShippingCost");

                    b.Property<DateTime>("ShippingDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ShippingId");

                    b.Property<decimal>("Total");

                    b.HasKey("OrderId");

                    b.HasIndex("CartItemIId")
                        .HasName("IX_Order_ShoppingCartIId");

                    b.HasIndex("CreditCardId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShippingId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("DokanyApp.BLL.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("OrderDetailsId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("DokanyApp.BLL.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("CategoryId");

                    b.Property<string>("CreationDate")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsUnicode(false);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("ProductAppreciate")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Quantity");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DokanyApp.BLL.ShippingAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<int>("UserId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ShippingAddress");
                });

            modelBuilder.Entity("DokanyApp.BLL.ShippingInfo", b =>
                {
                    b.Property<int>("ShippingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ShippingCost")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ShippingType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("ShippingId");

                    b.ToTable("ShippingInfo");
                });

            modelBuilder.Entity("DokanyApp.BLL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("(([FirstName]+' ')+[LastName])")
                        .HasMaxLength(101)
                        .IsUnicode(false);

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DokanyApp.BLL.CartItem", b =>
                {
                    b.HasOne("DokanyApp.BLL.User", "Customer")
                        .WithMany("CartItem")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CartItem_User");

                    b.HasOne("DokanyApp.BLL.Product", "Product")
                        .WithMany("CartItem")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_CartItem_Product");
                });

            modelBuilder.Entity("DokanyApp.BLL.Entities.ImageProduct", b =>
                {
                    b.HasOne("DokanyApp.BLL.Product", "Products")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DokanyApp.BLL.Order", b =>
                {
                    b.HasOne("DokanyApp.BLL.CartItem", "CartItemI")
                        .WithMany("Order")
                        .HasForeignKey("CartItemIId")
                        .HasConstraintName("FK_Order_CartItem");

                    b.HasOne("DokanyApp.BLL.CreditCard", "CreditCard")
                        .WithMany()
                        .HasForeignKey("CreditCardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DokanyApp.BLL.User", "Customer")
                        .WithMany("Order")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Order_User");

                    b.HasOne("DokanyApp.BLL.ShippingInfo", "Shipping")
                        .WithMany("Order")
                        .HasForeignKey("ShippingId")
                        .HasConstraintName("FK_Order_ShippingInfo");
                });

            modelBuilder.Entity("DokanyApp.BLL.OrderDetails", b =>
                {
                    b.HasOne("DokanyApp.BLL.Order", "OrderDetailsNavigation")
                        .WithOne("OrderDetails")
                        .HasForeignKey("DokanyApp.BLL.OrderDetails", "OrderDetailsId")
                        .HasConstraintName("FK_OrderDetails_Order");

                    b.HasOne("DokanyApp.BLL.Product", "OrderDetails1")
                        .WithOne("OrderDetails")
                        .HasForeignKey("DokanyApp.BLL.OrderDetails", "OrderDetailsId")
                        .HasConstraintName("FK_OrderDetails_Product");
                });

            modelBuilder.Entity("DokanyApp.BLL.Product", b =>
                {
                    b.HasOne("DokanyApp.BLL.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Product_Category");
                });

            modelBuilder.Entity("DokanyApp.BLL.ShippingAddress", b =>
                {
                    b.HasOne("DokanyApp.BLL.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
