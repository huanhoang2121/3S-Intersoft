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
    public class CategoryService : ICategoryService
    {
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        public CategoryService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #region Constructors
        
        #endregion
        
        #region Public Methods
        
        public IEnumerable<Category> Categories()
        {
            return _context.Categories;
        }
        
        public async Task<List<CategoryViewModel>> GetListCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModels = _mapper.Map<List<CategoryViewModel>>(categories);
            return viewModels;
        }

        public async Task<bool> CreateCategoryAsync(CategoryViewModel createViewModel)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = createViewModel.CategoryName,
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<CategoryViewModel> GetCategoryEditAsync(int id)
        {
            var store = await _context.Categories.FindAsync(id);
            var viewModel = _mapper.Map<CategoryViewModel>(store);
            return viewModel;
        }

        public async Task<bool> EditCategoryAsync(CategoryViewModel categoryEditViewModel)
        {
            try
            {
                var category = await _context.Categories.FirstOrDefaultAsync(u => u.Id == categoryEditViewModel.Id);
                category.CategoryName = categoryEditViewModel.CategoryName;
            
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                _context.Categories.Remove(category);
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
            return _context.Categories.Any(b => b.CategoryName == name && b.Id != id);
        }
        
        #endregion
        
    }//end
}