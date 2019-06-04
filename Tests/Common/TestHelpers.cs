using System;
using System.Collections.Generic;
using System.Linq;
using LoggingCodefirst.Infrastructure;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;

namespace Tests.Common
{
    public class TestHelpers
    {
        /// <summary>
        /// Get Mock DbSet
        /// </summary>
        /// <param name="entities"></param>
        /// <typeparam name="T">Model</typeparam>
        /// <returns></returns>
        internal static Mock<DbSet<T>> GetMockDbSet<T>(ICollection<T> entities) where T : class
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(entities.AsQueryable().Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(entities.AsQueryable().Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(entities.AsQueryable().ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(entities.AsQueryable().GetEnumerator());
            mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(entities.Add);
            return mockSet;
        }

        /// <summary>
        /// Get app db context
        /// </summary>
        /// <returns></returns>
        public static DataContext GetDataContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging()
                .Options;
            var context = new DataContext(options);
            Seed(context);
            return context;
        }

        /// <summary>
        /// Get app db context
        /// </summary>
        /// <returns></returns>
        public static DbContextOptionsBuilder GetDbContextOptionsBuilderOptions()
        {
            var builder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .EnableSensitiveDataLogging();
            return builder;
        }
        
        /// <summary>
        /// Seed fake data
        /// </summary>
        /// <param name="context">DataContext</param>
        private static void Seed(DataContext context)
        {
            var brands = new[]
            {
                new Brand { BrandName = "Adidas"} ,
                new Brand { BrandName = "Nike"} ,
            };
            context.Brands.AddRange(brands); 
            
            var categories = new[]
            {
                new Category { CategoryName = "Beers"} ,
                new Category { CategoryName = "Wines"} ,
            };
            context.Categories.AddRange(categories); 
            
            var admin = new Role { RoleName = "Admin", Description = "All roles",};
            var user = new Role { RoleName = "User", Description = "Add, edit",};
            context.Roles.Add(admin);
            context.Roles.Add(user);
            
            var users = new[]
            {
                new User
                {
                    Email = "huan.hv@3si.com.vn",
                    Password = SecurePasswordHasher.Hash("Pass1234"),
                    Fullname = "Hoàng Văn Huấn",
                    Address = "Huế",
                    ImagePath = "asdsad.jpg",
                    StoreId = 1,
                    Phone = "0964973404",
                    RoleId = admin.Id,
                    IsActive = true,
                } ,
                new User
                {
                    Email = "thang.dp@3si.com.vn",
                    Password = SecurePasswordHasher.Hash("Pass1234"),
                    Fullname = "Đặng Phước Thắng",
                    Address = "Huế",
                    ImagePath = "asdsad.jpg",
                    StoreId = 1,
                    Phone = "0964973404",
                    RoleId = user.Id,
                    IsActive = true,
                } ,
            };
            context.Users.AddRange(users); 
            
            var stores = new[]
            {
                new Store
                {
                    StoreName = "Hà Nội Store",
                    Phone = "0216444665",
                    Email = "hanoistore@3si.com.vn",
                    Street = "Duy Tân",
                    City = "Hà Nội",
                    State = "Hà Nội",
                    ZipCode = "000055"
                },
                new Store
                {
                    StoreName = "Huế Store",
                    Phone = "0216444665",
                    Email = "huestore@3si.com.vn",
                    Street = "Nguyễn Tri Phương",
                    City = "Huế",
                    State = "Thừa thiên Huế",
                    ZipCode = "000053"
                },
            };
            context.Stores.AddRange(stores);
            
            context.SaveChanges();
        }
    }
}