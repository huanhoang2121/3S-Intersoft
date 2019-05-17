using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Services
{
    public interface IBrandService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Get Brands
        /// </summary>
        /// <returns>Brands</returns>
        IEnumerable<Brand> Brands();
        
        /// <summary>
        /// GetListBrandAsync
        /// </summary>
        /// <returns>ListBrand</returns>
        Task<List<BrandViewModel>> GetListBrandAsync();
        
        /// <summary>
        /// CreateBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateBrandAsync(BrandViewModel brandViewModel);
        
        /// <summary>
        /// GetBrandEditAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Brand</returns>
        Task<BrandViewModel> GetBrandEditAsync(int id);
        
        /// <summary>
        /// EditBrandAsync
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditBrandAsync(BrandViewModel brandViewModel);
        
        /// <summary>
        /// DeleteBrandAsync
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteBrandAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="id">Brand id</param>
        /// <param name="name">Brand name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(int id, string name);
        
        #endregion
        
    }//end of interface
    
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
            return _context.Brands;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetListBrandAsync
        /// </summary>
        /// <returns>ListBrand</returns>
        public async Task<List<BrandViewModel>> GetListBrandAsync()
        {
            var brands = await _context.Brands.ToListAsync();
            var viewModels = _mapper.Map<List<BrandViewModel>>(brands);
            return viewModels;
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
                Console.WriteLine(e);
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
            var store = await _context.Brands.FindAsync(id);
            var viewModel = _mapper.Map<BrandViewModel>(store);
            return viewModel;
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
                Console.WriteLine(e);
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
                Console.WriteLine(e);
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
            return _context.Brands.Any(b => b.BrandName == name && b.Id != id);
        }
        
        #endregion
        
    }//end of class
}