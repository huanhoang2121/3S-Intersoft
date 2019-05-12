using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    public class StockController : Controller
    {
        #region Private Members
        
        private readonly IStockService _stockService;
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors
        
        public StockController(
            IStockService stockService, 
            IProductService productService, 
            IStoreService storeService, 
            LocalizationService localizer)
        {
            _localizer = localizer;
            _stockService = stockService;
            _productService = productService;
            _storeService = storeService;
        }

        #endregion
        
        #region Public Methods

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stockIndexViewModels = await _stockService.GetListStockAsync();
            return View(stockIndexViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName");
            ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StockViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _stockService.CreateStockAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName", createViewModel.ProductId);
                ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
                return View(createViewModel);
            }
            ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName", createViewModel.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
            return View(createViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? productid, int? storeid)
        {
            if (productid == null || storeid == null)
            {
                return BadRequest();
            }

            var stock = await _stockService.GetStockEditAsync(productid,storeid);
            if (stock == null)
            {
                return BadRequest();
            }
            ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName", stock.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName", stock.StoreId);
            return View(stock);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StockViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _stockService.EditStockAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName", editViewModel.ProductId);
                ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
                return View(editViewModel);
            }
            ViewData["ProductId"] = new SelectList(_productService.Products, "Id", "ProductName", editViewModel.ProductId);
            ViewData["StoreId"] = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
            return View(editViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? productid, int? storeid)
        {
            if (productid == null || storeid == null)
            {
                return BadRequest();
            }
            if (await _stockService.DeleteStockAsync(productid,storeid))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteFail").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}