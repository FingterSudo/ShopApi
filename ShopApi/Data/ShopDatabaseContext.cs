﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Data;

public partial class ShopDatabaseContext : DbContext
{
    public ShopDatabaseContext()
    {
    }

    public ShopDatabaseContext(DbContextOptions<ShopDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VC7AHN1; Database=ShopDatabase;Trusted_Connection=True;user= sa; password=1234$; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CUSTOMER");

            entity.ToTable("Customer");

            entity.HasIndex(e => new { e.LastName, e.FirstName }, "IndexCustomerName");

            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.FirstName).HasMaxLength(40);
            entity.Property(e => e.LastName).HasMaxLength(40);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ORDER");

            entity.ToTable("Order");

            entity.HasIndex(e => e.CustomerId, "IndexOrderCustomerId");

            entity.HasIndex(e => e.OrderDate, "IndexOrderOrderDate");

            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderNumber).HasMaxLength(10);
            entity.Property(e => e.TotalAmount)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ORDERITEM");

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderId, "IndexOrderItemOrderId");

            entity.HasIndex(e => e.ProductId, "IndexOrderItemProductId");

            entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PRODUCT");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductName, "IndexProductName");

            entity.HasIndex(e => e.SupplierId, "IndexProductSupplierId");

            entity.Property(e => e.Package).HasMaxLength(30);
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.UnitPrice)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SUPPLIER");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.Country, "IndexSupplierCountry");

            entity.HasIndex(e => e.CompanyName, "IndexSupplierName");

            entity.Property(e => e.City).HasMaxLength(40);
            entity.Property(e => e.CompanyName).HasMaxLength(40);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactTitle).HasMaxLength(40);
            entity.Property(e => e.Country).HasMaxLength(40);
            entity.Property(e => e.Fax).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(30);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERLOGIN");

            entity.ToTable("UserLogin");

            entity.Property(e => e.PasswordHash).HasMaxLength(2000);
            entity.Property(e => e.PasswordSalt).HasMaxLength(2000);
            entity.Property(e => e.RefreshToken).HasMaxLength(2000);
            entity.Property(e => e.TokenCreated).HasColumnType("datetime");
            entity.Property(e => e.TokenExpires).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_USERROLES");

            entity.HasIndex(e => e.UserId, "IndexUserRolesUserId");

            entity.Property(e => e.Roels)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USERROLES_REFERENCE_USERLOGINS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
