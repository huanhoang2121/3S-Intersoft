using System.Threading.Tasks;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    [Authorize]  
    public class CategoryController : Controller
    {
        #region Private Members

        private readonly ICategoryService _categoryService;
        private readonly ILocalizationService<CategoryResource> _localizer;

        #endregion
        
        #region Constructors

        public CategoryController(
            ICategoryService categoryService, 
            ILocalizationService<CategoryResource> localizer)
        {
            _localizer = localizer;
            _categoryService = categoryService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Index Category
        /// </summary>
        /// <returns>Category Index</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <returns>Category Create Partial</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>brand index</returns>
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
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateCategory").ToString();
                return PartialView("_CreatePartial", categoryViewModel);
            }
            return PartialView("_CreatePartial", categoryViewModel);
        }

        /// <summary>
        /// Edit Category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Edit Partial</returns>
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
        /// Edit Category
        /// </summary>
        /// <param name="categoryViewModel">CategoryViewModel</param>
        /// <returns>index category</returns>
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
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditCategory").ToString();
                return PartialView("_CreatePartial", categoryViewModel);
            }
            return PartialView("_CreatePartial", categoryViewModel);
        }

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id">Category id</param>
        /// <returns>Category index</returns>
        [HttpGet]       
        [Authorize(Roles = "Admin")]     
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