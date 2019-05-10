using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.DependencyInjection.Implementation
{
    public class StockService : IStockService
    {
        #region Private Members
        
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        #endregion
        
        #region Constructors
        
        public StockService(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        
        #endregion
        
        #region Public Properties

        public IEnumerable<Stock> Stocks => _context.Stocks;
        
        #endregion

        #region Public Methods
        
        public async Task<List<StockViewModel>> GetListStockAsync()
        {
            var stocks = await _context.Stocks
                .Include(s => s.Store)
                .Include(s => s.Product)
                .ToListAsync();
            var viewModels = _mapper.Map<List<StockViewModel>>(stocks);
            return viewModels;
        }

        public async Task<bool> CreateStockAsync(StockViewModel stockCreateViewModel)
        {
            try
            {
                var st = await _context.Stocks.FindAsync(stockCreateViewModel.ProductId, stockCreateViewModel.StoreId);
                if (st != null)
                {
                    st.Quanlity += stockCreateViewModel.Quanlity;
                    _context.Stocks.Update(st);
                    await _context.SaveChangesAsync();
                    return true;
                }
                var stock = new Stock
                {
                    ProductId = stockCreateViewModel.ProductId,
                    StoreId = stockCreateViewModel.StoreId,
                    Quanlity = stockCreateViewModel.Quanlity
                };
                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<StockViewModel> GetStockEditAsync(int? productid, int? storeid)
        {
            var stock = await _context.Stocks.FindAsync(productid, storeid);
            var viewModel = _mapper.Map<StockViewModel>(stock);
            return viewModel;
        }

        public async Task<bool> EditStockAsync(StockViewModel editViewModel)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(editViewModel.ProductId, editViewModel.StoreId);

                stock.ProductId = editViewModel.ProductId;
                stock.StoreId = editViewModel.StoreId;
                stock.Quanlity = editViewModel.Quanlity;
            
                _context.Stocks.Update(stock);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public async Task<bool> DeleteStockAsync(int? productid, int? storeid)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(productid,storeid);
                _context.Stocks.Remove(stock);
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