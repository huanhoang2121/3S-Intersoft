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
    public class CategoryService : ICategoryService
    {
        
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors
        
        public CategoryService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion
        
        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Get Categories
        /// </summary>
        /// <returns>Categories</returns>
        public IEnumerable<CategoryViewModel> GetCategories()
        {
            try
            {
                var categories = _context.Categories;
                var viewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
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
        /// CreateCategoryAsync
        /// </summary>
        /// <param name="createViewModel">CategoryViewModel</param>
        /// <returns>Could be Created?</returns>
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
                Log.Error(e.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// GetCategoryEditAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>CategoryViewModel</returns>
        public async Task<CategoryViewModel> GetCategoryEditAsync(int id)
        {
            try
            {
                var store = await _context.Categories.FindAsync(id);
                var viewModel = _mapper.Map<CategoryViewModel>(store);
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
        /// EditCategoryAsync
        /// </summary>
        /// <param name="categoryEditViewModel">CategoryViewModel</param>
        /// <returns>Could be Edited?</returns>
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
                Log.Error(e.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// DeleteCategoryAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Could be Deleted?</returns>
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
                Log.Error(e.Message);
                return false;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="name">Category name</param>
        /// <returns>ExistedName</returns>
        public bool IsExistedName(int id, string name)
        {
            try
            {
                return _context.Categories.Any(b => b.CategoryName == name && b.Id != id);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }
        
        #endregion
        
    }//end class
}