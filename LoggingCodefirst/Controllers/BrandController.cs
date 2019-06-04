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
    public class BrandController : Controller
    {
        #region Private Members

        private readonly IBrandService _brandService;
        private readonly ILocalizationService<BrandResource> _localizer;

        #endregion
        
        #region Constructors

        public BrandController(
            IBrandService brandService, 
            ILocalizationService<BrandResource> localizer)
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
        public IActionResult Index()
        {
            var brands =  _brandService.GetBrands();
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
        /// Create Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>Brand Index</returns>
        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.CreateBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateBrandSuccess").ToString();
                    return PartialView("_CreatePartial",brandViewModel); 
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateBrand").ToString();
                return PartialView("_CreatePartial", brandViewModel);
            }
            return PartialView("_CreatePartial", brandViewModel);
        }

        /// <summary>
        /// Edit Brand
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>Edit Partial</returns>
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
        /// Edit Brand
        /// </summary>
        /// <param name="brandViewModel">BrandViewModel</param>
        /// <returns>index brand</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.EditBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditBrandSuccess").ToString();
                    return PartialView("_EditPartial", brandViewModel);
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditBrand").ToString();
                return PartialView("_EditPartial", brandViewModel);
            }
            return PartialView("_EditPartial", brandViewModel);
        }

        /// <summary>
        /// Delete brand
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>index brand</returns>
        [HttpGet]  
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (await _brandService.DeleteBrandAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteBrandSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteBrand").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}