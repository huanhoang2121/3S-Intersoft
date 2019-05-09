using LoggingCodefirst.Models.Production;
using LoggingCodefirst.Models.Sales;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.SeedData
{
    public static class EntityConfigurations
    {
        public static void StoreEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<Store>().Property(t => t.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Store>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Store>().Property(t => t.StoreName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.Phone).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Store>().Property(t => t.Street).HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.City).HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.State).HasMaxLength(100);
        }
        public static void UserEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(t => t.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(t => t.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.Fullname).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.Address).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(t => t.Phone).HasMaxLength(20);
        }
        public static void CategoryEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().Property(t => t.CategoryName).IsRequired().HasMaxLength(100);
        }
        public static void BrandEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Brand>().Property(t => t.BrandName).IsRequired().HasMaxLength(100);
        }
        public static void ProductEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(t => t.ProductName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(t => t.BrandId).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.CategoryId).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.ModelYear).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.ListPrice).IsRequired();
        }
        public static void StockEntityConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Stock>().Property(t => t.ProductId).IsRequired();
            modelBuilder.Entity<Stock>().Property(t => t.StoreId).IsRequired();
            modelBuilder.Entity<Stock>().Property(t => t.Quanlity).IsRequired();
            modelBuilder.Entity<Stock>().HasKey(s=> new {s.ProductId, s.StoreId});
        }
    }
}