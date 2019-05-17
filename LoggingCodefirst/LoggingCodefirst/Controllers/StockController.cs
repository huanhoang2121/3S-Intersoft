using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    [ServiceFilter(typeof(AuthorizedActionFilter))]
    public class StockController : Controller
    {
        #region Private Members
        
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly LocalizationService<StockResource> _localizer;

        #endregion
        
        #region Constructors
        
        public StockController(
            IStockService stockService, 
            IProductService productService, 
            IStoreService storeService, 
            LocalizationService<StockResource> localizer)
        {
            _localizer = localizer;
            _stockService = stockService;
            _productService = productService;
            _storeService = storeService;
        }

        #endregion
        
        #region Public Methods

        /// <summary>
        /// Index Stock
        /// </summary>
        /// <returns>Index Stock</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockIndexViewModels = await _stockService.GetListStockAsync();
            return View(stockIndexViewModels);
        }

        /// <summary>
        /// Create Stock
        /// </summary>
        /// <returns>Create Stock</returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName");
            ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName");
            return PartialView("_CreatePartial");
        }

        /// <summary>
        ///  Create Stock
        /// </summary>
        /// <param name="createViewModel">StockViewModel</param>
        /// <returns>Index Stock</returns>
        [HttpPost]
        public async Task<IActionResult> Create(StockViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _stockService.CreateStockAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateStockSuccess").ToString();
                    return PartialView("_CreatePartial", createViewModel);
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateStock").ToString();
                ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName", createViewModel.ProductId);
                ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName", createViewModel.StoreId);
                return PartialView("_CreatePartial", createViewModel);
            }
            ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName", createViewModel.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName", createViewModel.StoreId);
            return PartialView("_CreatePartial", createViewModel);
        }

        /// <summary>
        /// Edit Stock
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>Edit Stock</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? productid, int? storeid)
        {
            if (productid == null || storeid == null)
            {
                return BadRequest();
            }

            var stock = await _stockService.GetStockEditAsync(productid.Value,storeid.Value);
            if (stock == null)
            {
                return BadRequest();
            }
            ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName", stock.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName", stock.StoreId);
            return PartialView("_EditPartial", stock);
        }

        /// <summary>
        /// Edit Stock
        /// </summary>
        /// <param name="editViewModel">StockViewModel</param>
        /// <returns>Index Stock</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(StockViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _stockService.EditStockAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditStockSuccess").ToString();
                    return PartialView("_EditPartial", editViewModel);
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditStock").ToString();
                ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName", editViewModel.ProductId);
                ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName", editViewModel.StoreId);
                return PartialView("_EditPartial", editViewModel);
            }
            ViewData["ProductId"] = new SelectList(_productService.Products(), "Id", "ProductName", editViewModel.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores(), "Id", "StoreName", editViewModel.StoreId);
            return PartialView("_EditPartial", editViewModel);
        }

        /// <summary>
        /// Delete Stock
        /// </summary>
        /// <param name="productid">product id</param>
        /// <param name="storeid">store id</param>
        /// <returns>Index Stock</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? productid, int? storeid)
        {
            if (productid == null || storeid == null)
            {
                return BadRequest();
            }
            if (await _stockService.DeleteStockAsync(productid.Value,storeid.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteStockSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteStock").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}