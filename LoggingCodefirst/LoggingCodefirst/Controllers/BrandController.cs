using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetListBrandAsync();
            return View(brands);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.CreateBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                return View(brandViewModel);
            }
            return View(brandViewModel);
        }

        [HttpGet]        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var brand = await _brandService.GetBrandEditAsync(id);
            if (brand == null)
            {
                return BadRequest();
            }
            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandViewModel brandViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _brandService.EditBrandAsync(brandViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                return View(brandViewModel);
            }
            return View(brandViewModel);
        }

        [HttpGet]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (await _brandService.DeleteBrandAsync(id))
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
