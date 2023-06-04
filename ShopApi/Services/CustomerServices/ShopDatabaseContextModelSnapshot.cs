﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopApi.Data;

#nullable disable

namespace ShopApi.Migrations
{
    [DbContext(typeof(ShopDatabaseContext))]
    partial class ShopDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id")
                        .HasName("PK_CUSTOMER");

                    b.HasIndex(new[] { "LastName", "FirstName" }, "IndexCustomerName");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("OrderNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<decimal?>("TotalAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(12, 2)")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id")
                        .HasName("PK_ORDER");

                    b.HasIndex(new[] { "CustomerId" }, "IndexOrderCustomerId");

                    b.HasIndex(new[] { "OrderDate" }, "IndexOrderOrderDate");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(12, 2)");

                    b.HasKey("Id")
                        .HasName("PK_ORDERITEM");

                    b.HasIndex(new[] { "OrderId" }, "IndexOrderItemOrderId");

                    b.HasIndex(new[] { "ProductId" }, "IndexOrderItemProductId");

                    b.ToTable("OrderItem", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnType("bit");

                    b.Property<string>("Package")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(12, 2)")
                        .HasDefaultValueSql("((0))");

                    b.HasKey("Id")
                        .HasName("PK_PRODUCT");

                    b.HasIndex(new[] { "ProductName" }, "IndexProductName");

                    b.HasIndex(new[] { "SupplierId" }, "IndexProductSupplierId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ContactName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactTitle")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Country")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Fax")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id")
                        .HasName("PK_SUPPLIER");

                    b.HasIndex(new[] { "Country" }, "IndexSupplierCountry");

                    b.HasIndex(new[] { "CompanyName" }, "IndexSupplierName");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasMaxLength(2000)
                        .HasColumnType("varbinary(2000)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasMaxLength(2000)
                        .HasColumnType("varbinary(2000)");

                    b.Property<byte[]>("RefreshToken")
                        .HasMaxLength(2000)
                        .HasColumnType("varbinary(2000)");

                    b.Property<DateTime?>("TokenCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("TokenExpires")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_USERLOGIN");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("ShopApi.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Roles")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_USERROLES");

                    b.HasIndex(new[] { "UserId" }, "IndexUserRolesUserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ShopApi.Models.Order", b =>
                {
                    b.HasOne("ShopApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK_ORDER_REFERENCE_CUSTOMER");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ShopApi.Models.OrderItem", b =>
                {
                    b.HasOne("ShopApi.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_ORDERITE_REFERENCE_ORDER");

                    b.HasOne("ShopApi.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ORDERITE_REFERENCE_PRODUCT");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.HasOne("ShopApi.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .IsRequired()
                        .HasConstraintName("FK_PRODUCT_REFERENCE_SUPPLIER");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ShopApi.Models.UserRole", b =>
                {
                    b.HasOne("ShopApi.Models.UserLogin", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_USERROLES_REFERENCE_USERLOGINS");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ShopApi.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("ShopApi.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopApi.Models.UserLogin", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
