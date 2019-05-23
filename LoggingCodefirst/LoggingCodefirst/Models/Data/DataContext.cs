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
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<Store>().Property(t => t.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Store>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Store>().Property(t => t.StoreName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.Phone).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Store>().Property(t => t.Street).HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.City).HasMaxLength(100);
            modelBuilder.Entity<Store>().Property(t => t.State).HasMaxLength(100);
            
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(t => t.Email).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<User>().Property(t => t.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.Fullname).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(t => t.Address).HasMaxLength(255);
            modelBuilder.Entity<User>().Property(t => t.Phone).HasMaxLength(20);
            modelBuilder.Entity<User>().Property(t => t.Role).HasMaxLength(50);
            
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().Property(t => t.CategoryName).IsRequired().HasMaxLength(100);
           
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Brand>().Property(t => t.BrandName).IsRequired().HasMaxLength(100);
            
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(t => t.ProductName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(t => t.BrandId).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.CategoryId).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.ModelYear).IsRequired();
            modelBuilder.Entity<Product>().Property(t => t.ListPrice).IsRequired(); 
            
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Stock>().Property(t => t.ProductId).IsRequired();
            modelBuilder.Entity<Stock>().Property(t => t.StoreId).IsRequired();
            modelBuilder.Entity<Stock>().Property(t => t.Quantity).IsRequired();
            modelBuilder.Entity<Stock>().HasKey(s=> new {s.ProductId, s.StoreId});
            
            
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