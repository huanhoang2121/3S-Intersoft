﻿// <auto-generated />
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoggingCodefirst.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190509084758_UpdateProImg")]
    partial class UpdateProImg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandName = "Adidas"
                        },
                        new
                        {
                            Id = 2,
                            BrandName = "Nike"
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Áo"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Quần"
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImagePath");

                    b.Property<decimal>("ListPrice");

                    b.Property<int>("ModelYear");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 2,
                            CategoryId = 1,
                            ImagePath = "05-02-2019-09-04-35.jpg",
                            ListPrice = 123000m,
                            ModelYear = 2017,
                            ProductName = "Áo nike"
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Stock", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("StoreId");

                    b.Property<int>("Quanlity");

                    b.HasKey("ProductId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("Stock");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            StoreId = 1,
                            Quanlity = 3
                        },
                        new
                        {
                            ProductId = 1,
                            StoreId = 2,
                            Quanlity = 2
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Sales.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Hà Nội",
                            Email = "hanoistore@3si.com.vn",
                            Phone = "0131651234",
                            State = "Hà Nội",
                            StoreName = "3S Hà Nội",
                            Street = "123 Phạm Hùng",
                            ZipCode = "100000"
                        },
                        new
                        {
                            Id = 2,
                            City = "Huế",
                            Email = "huestore@3si.com.vn",
                            Phone = "0903649741",
                            State = "Thừa thiên Huế",
                            StoreName = "3S Huế",
                            Street = "23 Hùng Vương",
                            ZipCode = "530000"
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Sales.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(255);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Fullname")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("StoreId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Huế, Thừa thiên Huế",
                            Email = "huan.hv@3si.com.vn",
                            Fullname = "Hoàng Văn Huấn",
                            IsActive = true,
                            Password = "10000:qvehCF89JW0RjZX1Q3KOKasOPnr0ToRgJKtkfTOr0WMxGa3y",
                            Phone = "0964973404",
                            StoreId = 2
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Product", b =>
                {
                    b.HasOne("LoggingCodefirst.Models.Production.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LoggingCodefirst.Models.Production.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Stock", b =>
                {
                    b.HasOne("LoggingCodefirst.Models.Production.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LoggingCodefirst.Models.Sales.Store", "Store")
                        .WithMany("Stocks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Sales.User", b =>
                {
                    b.HasOne("LoggingCodefirst.Models.Sales.Store", "Store")
                        .WithMany("Users")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
