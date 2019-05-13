using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    public class ProductController : Controller
    {
        #region Private Members

        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors
        
        public ProductController(
            IProductService productService,
            IBrandService brandService, 
            ICategoryService categoryService, 
            LocalizationService localizer)
        {
            _localizer = localizer;
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        #endregion

        #region Public Methods

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListProductAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateProductAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName", createViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName", createViewModel.CategoryId);
                return View(createViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName", createViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName", createViewModel.CategoryId);
            return View(createViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = await _productService.GetProductEditAsync(id);
            if (product == null)
            {
                return BadRequest();
            }

            ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.EditProductAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName", editViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName", editViewModel.CategoryId);
                return View(editViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.Brands, "Id", "BrandName", editViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories, "Id", "CategoryName", editViewModel.CategoryId);
            return View(editViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _productService.DeleteProductAsync(id))
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
