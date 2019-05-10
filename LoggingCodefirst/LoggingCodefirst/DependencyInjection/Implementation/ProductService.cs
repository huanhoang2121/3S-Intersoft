using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.DependencyInjection.Implementation
{
    public class ProductService : IProductService
    {
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors
        
        public ProductService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion
        
        #region Public Properties
        
        public IEnumerable<Product> Products => _context.Products;
        
        #endregion

        #region Public Methods

        public async Task<List<ProductViewModel>> GetListProductAsync()
        {
            var products = await _context.Products
                .Include(u => u.Brand)
                .Include(u => u.Category)
                .Include(s => s.Stocks)
                    .ThenInclude(i => i.Store)
                .ToListAsync();
            var viewModels = _mapper.Map<List<ProductViewModel>>(products);
            return viewModels;
        }

        public async Task<bool> CreateProductAsync(ProductViewModel createViewModel)
        {
            try
            {
                var product = new Product
                {
                    ProductName = createViewModel.ProductName,
                    BrandId = createViewModel.BrandId,
                    CategoryId = createViewModel.CategoryId,
                    ListPrice = createViewModel.ListPrice,
                    ModelYear = createViewModel.ModelYear,
                };
                
                if (createViewModel.ImageFile != null)
                {
                    var imageSrc = DateTime.Now.ToString("MMddyyyyHHmmss") + createViewModel.ImageFile.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageSrc );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await createViewModel.ImageFile.CopyToAsync(stream);
                    }
                    product.ImagePath = imageSrc;
                }
                
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<ProductViewModel> GetProductEditAsync(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            var viewModel = _mapper.Map<ProductViewModel>(product);
            return viewModel;
        }

        public async Task<bool> EditProductAsync(ProductViewModel editViewModel)
        {
            try
            {
                var product = await _context.Products.FindAsync(editViewModel.Id);
                product.ProductName = editViewModel.ProductName;
                product.BrandId = editViewModel.BrandId;
                product.CategoryId = editViewModel.CategoryId;
                product.ListPrice = editViewModel.ListPrice;
                product.ModelYear = editViewModel.ModelYear;
            
                if (editViewModel.ImageFile != null)
                {
                    var imageSrc = DateTime.Now.ToString("MMddyyyyHHmmss") + editViewModel.ImageFile.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageSrc );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await editViewModel.ImageFile.CopyToAsync(stream);
                    }
                    product.ImagePath = imageSrc;
                }
            
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int? id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        #endregion
        
    }//end of class
}