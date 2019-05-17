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
    public interface IStoreService
    {
        
        #region Public Methods
        
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        IEnumerable<Store> Stores();        
        
        /// <summary>
        /// GetListStoreAsync
        /// </summary>
        /// <returns>ListStore</returns>
        Task<List<StoreViewModel>> GetListStoreAsync();
        
        /// <summary>
        /// CreateStoreAsync
        /// </summary>
        /// <param name="createViewModel">StoreViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateStoreAsync(StoreViewModel createViewModel);
        
        /// <summary>
        /// GetStoreEditAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>StoreViewModel</returns>
        Task<StoreViewModel> GetStoreEditAsync(int id);
        
        /// <summary>
        /// StoreEditAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        Task<bool> StoreEditAsync(StoreViewModel editViewModel);
        
        /// <summary>
        /// DeleteStoreAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteStoreAsync(int id);
        
        /// <summary>
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">Store id</param>
        /// <param name="name">Store name</param>
        /// <returns>ExistedName</returns>
        bool IsExistedEmail(int id, string name);
        
        #endregion
        
    }//end of interface
    
    public class StoreService : IStoreService
    {
        
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors
        
        public StoreService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Stores
        /// </summary>
        /// <returns>Stores</returns>
        public IEnumerable<Store> Stores()
        {
            return _context.Stores;
        }

        /// <inheritdoc />
        /// <summary>
        /// GetListStoreAsync
        /// </summary>
        /// <returns>ListStore</returns>
        public async Task<List<StoreViewModel>> GetListStoreAsync()
        {
            var stores = await _context.Stores
                .Include(s => s.Stocks)
                .ThenInclude(i => i.Product)
                .ToListAsync();
            var viewModels = _mapper.Map<List<StoreViewModel>>(stores);
            return viewModels;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// CreateStoreAsync
        /// </summary>
        /// <param name="createViewModel">StoreViewModel</param>
        /// <returns>Could be Created?</returns>
        public async Task<bool> CreateStoreAsync(StoreViewModel createViewModel)
        {
            try
            {
                var store = new Store
                {
                    StoreName = createViewModel.StoreName,
                    Phone = createViewModel.Phone,
                    Email = createViewModel.Email,
                    Street = createViewModel.Street,
                    City = createViewModel.City,
                    State = createViewModel.State,
                    ZipCode = createViewModel.ZipCode
                };
                _context.Stores.Add(store);
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
        /// GetStoreEditAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>StoreViewModel</returns>
        public async Task<StoreViewModel> GetStoreEditAsync(int id)
        {
            var store = await _context.Stores.FindAsync(id);
            var viewModel = _mapper.Map<StoreViewModel>(store);
            return viewModel;
        }

        /// <inheritdoc />
        /// <summary>
        /// StoreEditAsync
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Could be Edited?</returns>
        public async Task<bool> StoreEditAsync(StoreViewModel editViewModel)
        {
            try
            {
                var store = await _context.Stores.FindAsync(editViewModel.Id);
            
                store.StoreName = editViewModel.StoreName;
                store.Phone = editViewModel.Phone;
                store.Street = editViewModel.Street;
                store.City = editViewModel.City;
                store.State = editViewModel.State;
                store.ZipCode = editViewModel.ZipCode;
            
                _context.Stores.Update(store);
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
        /// DeleteStoreAsync
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Could be Deleted?</returns>
        public async Task<bool> DeleteStoreAsync(int id)
        {
            try
            {
                var store = await _context.Stores.FindAsync(id);
                _context.Stores.Remove(store);
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
        /// IsExistedEmail
        /// </summary>
        /// <param name="id">Store id</param>
        /// <param name="email">Store email</param>
        /// <returns>ExistedEmail</returns>
        public bool IsExistedEmail(int id, string email)
        {
            return _context.Stores.Any(b => b.Email == email && b.Id != id);
        }

        #endregion
        
    }//end of class
}