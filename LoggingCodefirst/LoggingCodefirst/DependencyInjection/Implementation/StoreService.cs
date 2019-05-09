using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Sales;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.DependencyInjection.Implementation
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
        
        #region Public Properties

        public IEnumerable<Store> Stores => _context.Stores;
        
        #endregion

        #region Public Methods

        public async Task<List<StoreViewModel>> GetListStoreAsync()
        {
            var stores = await _context.Stores
                .Include(s => s.Stocks)
                .ThenInclude(i => i.Product)
                .ToListAsync();
            var viewModels = _mapper.Map<List<StoreViewModel>>(stores);
            return viewModels;
        }
        
        public async Task<bool> CreateStoreAsync(StoreViewModel storeCreateModel)
        {
            try
            {
                var store = new Store
                {
                    StoreName = storeCreateModel.StoreName,
                    Phone = storeCreateModel.Phone,
                    Email = storeCreateModel.Email,
                    Street = storeCreateModel.Street,
                    City = storeCreateModel.City,
                    State = storeCreateModel.State,
                    ZipCode = storeCreateModel.ZipCode
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

        public async Task<StoreViewModel> GetStoreEditAsync(int? id)
        {
            var store = await _context.Stores.FindAsync(id);
            var viewModel = _mapper.Map<StoreViewModel>(store);
            return viewModel;
        }

        public async Task<bool> StoreEditAsync(StoreViewModel editViewModel)
        {
            try
            {
                var store = await _context.Stores.FindAsync(editViewModel.Id);
            
                store.StoreName = editViewModel.StoreName;
                store.Email = editViewModel.Email;
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

        public async Task<bool> DeleteStoreAsync(int? id)
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
        
        #endregion
        
    }//end of class
}