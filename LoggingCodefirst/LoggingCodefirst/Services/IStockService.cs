using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LoggingCodefirst.Models;
using LoggingCodefirst.Models.Data;
using LoggingCodefirst.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LoggingCodefirst.Services
{
    public interface IStockService
    {
        
        #region Public Methods

        /// <summary>
        /// Get Stocks
        /// </summary>
        /// <returns>Stocks</returns>
        IEnumerable<Stock> Stocks();      
        
        /// <summary>
        /// GetListStockAsync
        /// </summary>
        /// <returns>ListStock</returns>
        Task<List<StockViewModel>> GetListStockAsync();
        
        /// <summary>
        /// CreateStockAsync
        /// </summary>
        /// <param name="createViewModel">StockViewModel</param>
        /// <returns>Could be Created?</returns>
        Task<bool> CreateStockAsync(StockViewModel createViewModel);
        
        /// <summary>
        /// GetStockEditAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>StockViewModel</returns>
        Task<StockViewModel> GetStockEditAsync(int productid, int storeid);
        
        /// <summary>
        /// EditStockAsync
        /// </summary>
        /// <param name="editViewModel">StockViewModel</param>
        /// <returns>Could be Edited?</returns>
        Task<bool> EditStockAsync(StockViewModel editViewModel);
        
        /// <summary>
        /// DeleteStockAsync
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>Could be Deleted?</returns>
        Task<bool> DeleteStockAsync(int productid, int storeid);
        
        #endregion

    }//end of interface
    
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
        public IEnumerable<Stock> Stocks()
        {
            return _context.Stocks;
        }
        
        /// <inheritdoc />
        /// <summary>
        /// GetListStockAsync
        /// </summary>
        /// <returns>ListStock</returns>
        public async Task<List<StockViewModel>> GetListStockAsync()
        {
            var stocks = await _context.Stocks
                .Include(s => s.Store)
                .Include(s => s.Product)
                .ToListAsync();
            var viewModels = _mapper.Map<List<StockViewModel>>(stocks);
            return viewModels;
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
                Console.WriteLine(e);
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
            var stock = await _context.Stocks.FindAsync(productid, storeid);
            var viewModel = _mapper.Map<StockViewModel>(stock);
            return viewModel;
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
                Console.WriteLine(e);
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
                Console.WriteLine(e);
                return false;
            }
        }
        
        #endregion
        
    }//end of class
}