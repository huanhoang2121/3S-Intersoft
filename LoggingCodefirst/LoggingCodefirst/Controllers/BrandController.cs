using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services.Interface;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class BrandController : Controller
    {
        #region Private Members

        private readonly IBrandService _brandService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors

        public BrandController(
            IBrandService brandService, 
            LocalizationService localizer)
        {
            _localizer = localizer;
            _brandService = brandService;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Index Brand function
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpGet]
        [ServiceFilter(typeof(SampleActionFilter))]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetListBrandAsync();
            return View(brands);
        }

        /// <summary>
        /// Create Brand Get Function
        /// </summary>
        /// <returns>Brand Create View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePartial");
        }

        /// <summary>
        /// Create Brand Post Function
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.CreateBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return PartialView("_CreatePartial",brandViewModel); 
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                return PartialView("_CreatePartial", brandViewModel);
            }
            return PartialView("_CreatePartial", brandViewModel);
        }

        /// <summary>
        /// Edit Brand Get Function
        /// </summary>
        /// <returns>Brand Edit View</returns>
        [HttpGet]        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var brand = await _brandService.GetBrandEditAsync(id.Value);
            if (brand == null)
            {
                return BadRequest();
            }
            return PartialView("_EditPartial", brand);
        }

        /// <summary>
        /// Edit Brand Post Function
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.EditBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return PartialView("_EditPartial", brandViewModel);
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                return PartialView("_EditPartial", brandViewModel);
            }
            return PartialView("_EditPartial", brandViewModel);
        }

        /// <summary>
        /// Delete Brand Get Function
        /// </summary>
        /// <returns>Brand Index View</returns>
        [HttpGet]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (await _brandService.DeleteBrandAsync(id.Value))
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
