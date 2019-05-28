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
            try
            {
                return _context.Stores;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                throw;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// GetListStoreAsync
        /// </summary>
        /// <returns>ListStore</returns>
        public async Task<List<StoreViewModel>> GetListStoreAsync()
        {
            try
            {
                var stores = await _context.Stores
                    .Include(s => s.Stocks)
                    .ThenInclude(i => i.Product)
                    .ToListAsync();
                var viewModels = _mapper.Map<List<StoreViewModel>>(stores);
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
                Log.Error(e.Message);
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
            try
            {
                var store = await _context.Stores.FindAsync(id);
                var viewModel = _mapper.Map<StoreViewModel>(store);
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
                Log.Error(e.Message);
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
                Log.Error(e.Message);
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
            try
            {
                return _context.Stores.Any(b => b.Email == email && b.Id != id);
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