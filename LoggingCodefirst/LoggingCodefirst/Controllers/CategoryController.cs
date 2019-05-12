using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class CategoryController : Controller
    {
        #region Private Members

        private readonly ICategoryService _categoryService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors

        public CategoryController(
            ICategoryService categoryService, 
            LocalizationService localizer)
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
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
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
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
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
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteFail").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}
