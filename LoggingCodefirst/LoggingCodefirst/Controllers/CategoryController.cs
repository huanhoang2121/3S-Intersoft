using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Controllers
{
    public class CategoryController : Controller
    {
        #region Private Members

        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<CategoryController> _localizer;

        #endregion
        
        #region Constructors

        public CategoryController(
            ICategoryService categoryService, 
            IStringLocalizer<CategoryController> localizer)
        {
            _localizer = localizer;
            _categoryService = categoryService;
        }

        #endregion

        #region Public Methods


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetListCategoryAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryService.CreateCategoryAsync(categoryViewModel))
                {
                    TempData["SuccessMessage"] = _localizer["Create successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                return View(categoryViewModel);
            }
            return View(categoryViewModel);
        }

        [HttpGet]        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = await _categoryService.GetCategoryEditAsync(id);
            if (category == null)
            {
                return BadRequest();
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _categoryService.EditCategoryAsync(categoryViewModel))
                {
                    TempData["SuccessMessage"] = _localizer["Edit successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                return View(categoryViewModel);
            }
            return View(categoryViewModel);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (await _categoryService.DeleteCategoryAsync(id))
            {
                TempData["SuccessMessage"] = _localizer["Delete successfully!"].ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer["Delete fail!"].ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}
