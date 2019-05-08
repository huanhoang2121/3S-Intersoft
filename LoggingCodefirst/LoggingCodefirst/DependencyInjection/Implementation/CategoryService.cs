using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Production;
using LoggingCodefirst.ViewModels.CategoryViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.DependencyInjection.Implementation
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
        
        #region Public Properties

        public IEnumerable<Category> Categories => _context.Categories;
        
        public async Task<List<CategoryIndexViewModel>> GetListCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModels = _mapper.Map<List<CategoryIndexViewModel>>(categories);
            return viewModels;
        }
        
        #endregion

        #region Public Methods

        public async Task<bool> CreateCategoryAsync(CategoryCreateViewModel createViewModel)
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

        public async Task<CategoryEditViewModel> GetCategoryEditAsync(int? id)
        {
            var store = await _context.Categories.FindAsync(id);
            var viewModel = _mapper.Map<CategoryEditViewModel>(store);
            return viewModel;
        }

        public async Task<bool> EditCategoryAsync(CategoryEditViewModel categoryEditViewModel)
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

        public async Task<bool> DeleteCategoryAsync(int? id)
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
        
        #endregion
        
    }//end
}