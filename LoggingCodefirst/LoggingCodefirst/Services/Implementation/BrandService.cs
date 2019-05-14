using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.Services.Interface;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Services.Implementation
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

        public IEnumerable<Brand> Brands()
        {
            return _context.Brands;
        }

        public async Task<List<BrandViewModel>> GetListBrandAsync()
        {
            var brands = await _context.Brands.ToListAsync();
            var viewModels = _mapper.Map<List<BrandViewModel>>(brands);
            return viewModels;
        }

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

        public async Task<BrandViewModel> GetBrandEditAsync(int id)
        {
            var store = await _context.Brands.FindAsync(id);
            var viewModel = _mapper.Map<BrandViewModel>(store);
            return viewModel;
        }

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

        public bool IsExistedName(int id, string name)
        {
            return _context.Brands.Any(b => b.BrandName == name && b.Id != id);
        }
        
        #endregion
        
    }//end of class
}