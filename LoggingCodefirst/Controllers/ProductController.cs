using System.Threading.Tasks;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        #region Private Members

        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly ILocalizationService<ProductResource> _localizer;

        #endregion
        
        #region Constructors
        
        public ProductController(
            IProductService productService,
            IBrandService brandService, 
            ICategoryService categoryService, 
            ILocalizationService<ProductResource> localizer)
        {
            _localizer = localizer;
            _productService = productService;
            _brandService = brandService;
            _categoryService = categoryService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Index Product
        /// </summary>
        /// <returns>Index Product</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <returns>Create Product</returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName");
            return View();
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="createViewModel">ProductViewModel</param>
        /// <returns>Index Product</returns>
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.CreateProductAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateProductSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateProduct").ToString();
                ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName", createViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName", createViewModel.CategoryId);
                return View(createViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName", createViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName", createViewModel.CategoryId);
            return View(createViewModel);
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Edit Product</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var product = await _productService.GetProductEditAsync(id.Value);
            if (product == null)
            {
                return BadRequest();
            }

            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        /// <summary>
        /// Edit Product
        /// </summary>
        /// <param name="editViewModel">ProductViewModel</param>
        /// <returns>Index Product</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _productService.EditProductAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditProductSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditProduct").ToString();
                ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName", editViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName", editViewModel.CategoryId);
                return View(editViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.GetBrands(), "Id", "BrandName", editViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.GetCategories(), "Id", "CategoryName", editViewModel.CategoryId);
            return View(editViewModel);
        }
        
        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Index Product</returns>
        [HttpGet]  
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _productService.DeleteProductAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteProductSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteProduct").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}
