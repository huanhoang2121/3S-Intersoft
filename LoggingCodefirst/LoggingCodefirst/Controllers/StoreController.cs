using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Controllers
{
    public class StoreController : Controller
    {
        #region Private Members

        private readonly IStoreService _storeService;
        private readonly IStringLocalizer<StoreController> _localizer;

        #endregion
        
        #region Constructors
        
        public StoreController(
            IStoreService storeService, 
            IStringLocalizer<StoreController> localizer)
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
                    TempData["SuccessMessage"] = _localizer["Create successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
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
                    TempData["SuccessMessage"] = _localizer["Edit successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
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
                TempData["SuccessMessage"] = _localizer["Delete successfully!"].ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer["Delete fail!"].ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}