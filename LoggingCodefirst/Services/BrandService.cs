using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BrandService : IBrandService
    {
        
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors

        public BrandService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Get Brands
        /// </summary>
        /// <returns>Brands</returns>
        public IEnumerable<Brand> Brands()
        {
            try
            {
                return _context.Brands;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// GetListBrandAsync
        /// </summary>
        /// <returns>ListBrand</returns>
        public async Task<List<BrandViewModel>> GetListBrandAsync()
        {
            try
            {
                var brands = await _context.Brands.ToListAsync();
                var viewModels = _mapper.Map<List<BrandViewModel>>(brands);
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
        /// CreateBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Created?</returns>
        public async Task<bool> CreateBrandAsync(BrandViewModel brandViewModel)
        {
            try
            {
                var brand = new Brand
                {
                    BrandName = brandViewModel.BrandName,
                };
                _context.Brands.Add(brand);
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
        /// GetBrandEditAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Brand</returns>
        public async Task<BrandViewModel> GetBrandEditAsync(int id)
        {
            try
            {
                var store = await _context.Brands.FindAsync(id);
                var viewModel = _mapper.Map<BrandViewModel>(store);
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
        /// EditBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Edited?</returns>
        public async Task<bool> EditBrandAsync(BrandViewModel brandViewModel)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(brandViewModel.Id);
                brand.BrandName = brandViewModel.BrandName;
            
                _context.Brands.Update(brand);
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
        /// DeleteBrandAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Could be Deleted?</returns>
        public async Task<bool> DeleteBrandAsync(int id)
        {
            try
            {
                var brand = await _context.Brands.FindAsync(id);
                _context.Brands.Remove(brand);
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
        /// IsExistedName
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <param name="name">Brand name</param>
        /// <returns>ExistedName</returns>
        public bool IsExistedName(int id, string name)
        {
            try
            {
                return _context.Brands.Any(b => b.BrandName == name && b.Id != id);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }
        
        #endregion
        
    }//end of class
}