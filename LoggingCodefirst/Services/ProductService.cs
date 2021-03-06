﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LoggingCodefirst.Services
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

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Products
        /// </summary>
        /// <returns>Products</returns>
        public IEnumerable<ProductViewModel> GetProducts()
        {
            try
            {
                var products = _context.Products
                    .Include(u => u.Brand)
                    .Include(u => u.Category)
                    .Include(s => s.Stocks)
                    .ThenInclude(i => i.Store);
                var viewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products);
                return viewModels;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// CreateProductAsync
        /// </summary>
        /// <param name="createViewModel">ProductViewModel</param>
        /// <returns>Could be Created?</returns>
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
                Log.Error(e.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// GetProductEditAsync
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>ProductViewModel</returns>
        public async Task<ProductViewModel> GetProductEditAsync(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                var viewModel = _mapper.Map<ProductViewModel>(product);
                return viewModel;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// EditProductAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
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
                Log.Error(e.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// DeleteProductAsync
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Could be Deleted?</returns>
        public async Task<bool> DeleteProductAsync(int id)
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
                Log.Error(e.Message);
                return false;
            }
        }
        
        #endregion
        
    }//end of class
}