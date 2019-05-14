using System.Threading.Tasks;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services.Interface;
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

        /// <summary>
        /// Index Product Get Function
        /// </summary>
        /// <returns>Index Product</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetListProductAsync();
            return View(products);
        }

        /// <summary>
        /// Create Product Get Function
        /// </summary>
        /// <returns>Create Product</returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName");
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName");
            return View();
        }

        /// <summary>
        /// Create Product Post Function
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Index Product</returns>
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
                ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName", createViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName", createViewModel.CategoryId);
                return View(createViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName", createViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName", createViewModel.CategoryId);
            return View(createViewModel);
        }

        /// <summary>
        /// Edit Product Get Function
        /// </summary>
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

            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName", product.CategoryId);
            return View(product);
        }

        /// <summary>
        /// Edit Product Post Function
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Index Product</returns>
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
                ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName", editViewModel.BrandId);
                ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName", editViewModel.CategoryId);
                return View(editViewModel);
            }
            ViewData["BrandId"] = new SelectList(_brandService.Brands(), "Id", "BrandName", editViewModel.BrandId);
            ViewData["CategoryId"] = new SelectList(_categoryService.Categories(), "Id", "CategoryName", editViewModel.CategoryId);
            return View(editViewModel);
        }
        
        /// <summary>
        /// Delete Product Post Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Index Product</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _productService.DeleteProductAsync(id.Value))
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
