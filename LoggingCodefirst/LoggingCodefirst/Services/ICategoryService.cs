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
    public interface ICategoryService
    {
        
        #region Public Methods

        /// <summary>
        /// Get Categories
        /// </summary>
        /// <returns>Categories</returns>
        IEnumerable<Category> Categories();  
        
        /// <summary>
        /// GetListCategoryAsync
        /// </summary>
        /// <returns>ListCategory</returns>
        Task<List<CategoryViewModel>> GetListCategoryAsync();
        
        /// <summary>
        /// CreateCategoryAsync
        /// </summary>
        /// <param name="categoryCreateViewModel">CategoryViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateCategoryAsync(CategoryViewModel categoryCreateViewModel);
        
        /// <summary>
        /// GetCategoryEditAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>CategoryViewModel</returns>
        Task<CategoryViewModel> GetCategoryEditAsync(int id);
        
        /// <summary>
        /// EditCategoryAsync
        /// </summary>
        /// <param name="createViewModel">CategoryViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditCategoryAsync(CategoryViewModel createViewModel);
        
        /// <summary>
        /// DeleteCategoryAsync
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteCategoryAsync(int id);
        
        /// <summary>
        /// IsExistedName
        /// </summary>
        /// <param name="id">Category id</param>
        /// <param name="name">Category name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedName(int id, string name);
        
        #endregion

    }//end of interface
    
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
        public IEnumerable<Category> Categories()
        {
            return _context.Categories;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetListCategoryAsync
        /// </summary>
        /// <returns>ListCategory</returns>
        public async Task<List<CategoryViewModel>> GetListCategoryAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var viewModels = _mapper.Map<List<CategoryViewModel>>(categories);
            return viewModels;
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
                Console.WriteLine(e);
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
            var store = await _context.Categories.FindAsync(id);
            var viewModel = _mapper.Map<CategoryViewModel>(store);
            return viewModel;
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
                Console.WriteLine(e);
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
                Console.WriteLine(e);
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
            return _context.Categories.Any(b => b.CategoryName == name && b.Id != id);
        }
        
        #endregion
        
    }//end class
}