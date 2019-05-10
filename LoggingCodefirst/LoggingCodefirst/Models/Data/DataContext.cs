using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
//        Sales
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
//        Production
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {  
//            EntityConfiguration
            modelBuilder.StoreEntityConfiguration();
            modelBuilder.UserEntityConfiguration();
            modelBuilder.CategoryEntityConfiguration();
            modelBuilder.BrandEntityConfiguration();
            modelBuilder.ProductEntityConfiguration();
            modelBuilder.StockEntityConfiguration();
            
//            ForeignKey
            modelBuilder.Entity<User>().HasOne(s => s.Store).WithMany(g => g.Users).HasForeignKey(s => s.StoreId);
            
            modelBuilder.Entity<Product>().HasOne(s => s.Category).WithMany(g => g.Products).HasForeignKey(s => s.CategoryId);
            modelBuilder.Entity<Product>().HasOne(s => s.Brand).WithMany(g => g.Products).HasForeignKey(s => s.BrandId);
            
            modelBuilder.Entity<Stock>().HasOne(s => s.Store).WithMany(g => g.Stocks).HasForeignKey(s => s.StoreId);
            modelBuilder.Entity<Stock>().HasOne(s => s.Product).WithMany(g => g.Stocks).HasForeignKey(s => s.ProductId);
            
//            SeedData
            modelBuilder.Seed();
        } 
    }
}