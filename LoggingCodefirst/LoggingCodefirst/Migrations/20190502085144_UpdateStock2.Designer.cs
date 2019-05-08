﻿// <auto-generated />
using LoggingCodefirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoggingCodefirst.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190502085144_UpdateStock2")]
    partial class UpdateStock2
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
                        });
                });

            modelBuilder.Entity("LoggingCodefirst.Models.Production.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId");

                    b.Property<int>("CategoryId");

                    b.Property<decimal>("ListPrice");

                    b.Property<int>("ModelYear");

                    b.Property<string>("ProductImage")
                        .IsRequired();

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
                            BrandId = 1,
                            CategoryId = 1,
                            ListPrice = 123000m,
                            ModelYear = 1,
                            ProductImage = "en-US.png",
                            ProductName = "Áo adidas 1"
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
                            Quanlity = 1
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
                            Email = "store@3si.com.vn",
                            Phone = "0131651234",
                            State = "Hà Nội",
                            StoreName = "3S Huế",
                            Street = "Phạm Hùng",
                            ZipCode = "HANOI123"
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
                            Address = "Thừa thiên Huế",
                            Email = "huan.hv@3si.com.vn",
                            Fullname = "Hoàng Văn Huấn",
                            IsActive = true,
                            Password = "10000:Eab/O9Xi0QcTahzzLKtC5AKGw0QId+BnTndyJSzZ/pP8zfG8",
                            Phone = "0131651234",
                            StoreId = 1
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
