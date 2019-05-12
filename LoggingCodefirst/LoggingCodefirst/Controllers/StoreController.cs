using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class StoreController : Controller
    {
        #region Private Members

        private readonly IStoreService _storeService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors
        
        public StoreController(
            IStoreService storeService, 
            LocalizationService localizer)
        {
            _localizer = localizer;
            _storeService = storeService;
        }

        #endregion

        #region Public Methods
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _storeService.GetListStoreAsync();
            return View(stores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(StoreViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _storeService.CreateStoreAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                return View(createViewModel);
            }
            return View(createViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var user = await _storeService.GetStoreEditAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return View(user);
        }
                
        [HttpPost]
        public async Task<IActionResult> Edit(StoreViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _storeService.StoreEditAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                return View(editViewModel);
            }
            return View(editViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _storeService.DeleteStoreAsync(id))
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