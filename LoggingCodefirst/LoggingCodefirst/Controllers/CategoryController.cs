using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    [ServiceFilter(typeof(AuthorizedActionFilter))]
    public class CategoryController : Controller
    {
        #region Private Members

        private readonly ICategoryService _categoryService;
        private readonly LocalizationService<CategoryResource> _localizer;

        #endregion
        
        #region Constructors

        public CategoryController(
            ICategoryService categoryService, 
            LocalizationService<CategoryResource> localizer)
        {
            _localizer = localizer;
            _categoryService = categoryService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Index Category Get Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetListCategoryAsync();
            return View(categories);
        }

        /// <summary>
        /// Create Category Get Function
        /// </summary>
        /// <returns>Category Create View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        /// <summary>
        /// Create Category Post Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryService.CreateCategoryAsync(categoryViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateCategorySuccess").ToString();
                    return PartialView("_CreatePartial",categoryViewModel); 
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateCategory").ToString();
                return PartialView("_CreatePartial", categoryViewModel);
            }
            return PartialView("_CreatePartial", categoryViewModel);
        }

        /// <summary>
        /// Edit Category Get Function
        /// </summary>
        /// <returns>Category Edit View</returns>
        [HttpGet]        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = await _categoryService.GetCategoryEditAsync(id.Value);
            if (category == null)
            {
                return BadRequest();
            }
            return PartialView("_EditPartial", category);
        }

        /// <summary>
        /// Edit Category Post Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryService.EditCategoryAsync(categoryViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditCategorySuccess").ToString();
                    return PartialView("_CreatePartial",categoryViewModel); 
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditCategory").ToString();
                return PartialView("_CreatePartial", categoryViewModel);
            }
            return PartialView("_CreatePartial", categoryViewModel);
        }

        /// <summary>
        /// Delete Category Get Function
        /// </summary>
        /// <returns>Category Index View</returns>
        [HttpGet]        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (await _categoryService.DeleteCategoryAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteCategorySuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteCategory").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}