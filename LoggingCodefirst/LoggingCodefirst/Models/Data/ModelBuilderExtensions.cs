using LoggingCodefirst.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Models.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
//            Sales
            modelBuilder.Entity<Store>().HasData(  
                new Store
                {
                    Id = 1, 
                    Email = "hanoistore@3si.com.vn", 
                    StoreName = "3S Hà Nội", 
                    Phone = "0131651234", 
                    Street = "123 Phạm Hùng", 
                    City = "Hà Nội", 
                    State = "Hà Nội",
                    ZipCode = "100000"
                },
                new Store
                {
                    Id = 2, 
                    Email = "huestore@3si.com.vn", 
                    StoreName = "3S Huế", 
                    Phone = "0903649741", 
                    Street = "23 Hùng Vương", 
                    City = "Huế", 
                    State = "Thừa thiên Huế",
                    ZipCode = "530000"
                }
            ); 
            modelBuilder.Entity<User>().HasData(  
                new User
                {
                    Id = 1, 
                    Email = "huan.hv@3si.com.vn", 
                    Fullname = "Hoàng Văn Huấn", 
                    Password = SecurePasswordHasher.Hash("Pass1234"), 
                    Phone = "0964973404", 
                    Address = "Huế, Thừa thiên Huế", 
                    StoreId = 2, 
                    ImagePath = "05172019110557huan.jpg", 
                    IsActive = true
                }
            );  
//        Production         
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = 1, CategoryName = "Áo" },
                new Category{ Id = 2, CategoryName = "Quần" }
            );       
            modelBuilder.Entity<Brand>().HasData(  
                new Brand{ Id = 1, BrandName = "Adidas"},
                new Brand{ Id = 2, BrandName = "Nike"}
            ); 
            modelBuilder.Entity<Product>().HasData(  
                new Product
                {
                    Id = 1, 
                    ProductName = "Áo nike", 
                    CategoryId = 1, 
                    BrandId = 2, 
                    ModelYear = 2017, 
                    ImagePath = "05-02-2019-09-04-35.jpg", 
                    ListPrice = 123000
                }
            );
            modelBuilder.Entity<Stock>().HasData(  
                new Stock{ StoreId = 1, ProductId = 1, Quantity = 3 },
                new Stock{ StoreId = 2, ProductId = 1, Quantity = 2 }
            ); 
        }
    }
}