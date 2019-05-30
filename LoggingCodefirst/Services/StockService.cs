using System;
using System.Collections.Generic;
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

        #region Public Methods
        
        /// <inheritdoc />
        /// <summary>
        /// Get Stocks
        /// </summary>
        /// <returns>Stocks</returns>
        public IEnumerable<StockViewModel> GetStocks()
        {
            try
            {
                var stocks =  _context.Stocks
                    .Include(s => s.Store)
                    .Include(s => s.Product);
                var viewModels = _mapper.Map<IEnumerable<StockViewModel>>(stocks);
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
        /// CreateStockAsync
        /// </summary>
        /// <param name="createViewModel">StockViewModel</param>
        /// <returns>Could be Created?</returns>
        public async Task<bool> CreateStockAsync(StockViewModel createViewModel)
        {
            try
            {
                var st = await _context.Stocks.FindAsync(createViewModel.ProductId, createViewModel.StoreId);
                if (st != null)
                {
                    st.Quantity += createViewModel.Quantity;
                    _context.Stocks.Update(st);
                    await _context.SaveChangesAsync();
                    return true;
                }
                var stock = new Stock
                {
                    ProductId = createViewModel.ProductId,
                    StoreId = createViewModel.StoreId,
                    Quantity = createViewModel.Quantity
                };
                _context.Stocks.Add(stock);
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
        /// GetStockEditAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>StockViewModel</returns>
        public async Task<StockViewModel> GetStockEditAsync(int productid, int storeid)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(productid, storeid);
                var viewModel = _mapper.Map<StockViewModel>(stock);
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
        /// EditStockAsync
        /// </summary>
        /// <param name="editViewModel">StockViewModel</param>
        /// <returns>Could be Edited?</returns>
        public async Task<bool> EditStockAsync(StockViewModel editViewModel)
        {
            try
            {
                var stock = await _context.Stocks.FindAsync(editViewModel.ProductId, editViewModel.StoreId);

                stock.ProductId = editViewModel.ProductId;
                stock.StoreId = editViewModel.StoreId;
                stock.Quantity = editViewModel.Quantity;
            
                _context.Stocks.Update(stock);
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
        /// DeleteStockAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>Could be Deleted?</returns>
        public async Task<bool> DeleteStockAsync(int productid, int storeid)
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
                Log.Error(e.Message);
                return false;
            }
        }
        
        #endregion
        
    }//end of class
}