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
    public class StoreController : Controller
    {
        #region Private Members

        private readonly IStoreService _storeService;
        private readonly ILocalizationService<StoreResource> _localizer;

        #endregion
        
        #region Constructors
        
        public StoreController(
            IStoreService storeService, 
            ILocalizationService<StoreResource> localizer)
        {
            _localizer = localizer;
            _storeService = storeService;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Index Store
        /// </summary>
        /// <returns>Index Store</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var stores = _storeService.GetStores();
            return View(stores);
        }

        /// <summary>
        /// Create Store
        /// </summary>
        /// <returns>Create Store</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Create Store
        /// </summary>
        /// <param name="createViewModel">StoreViewModel</param>
        /// <returns>Index Store</returns>
        [HttpPost]
        public async Task<IActionResult> Create(StoreViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _storeService.CreateStoreAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateStoreSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateStore").ToString();
                return View(createViewModel);
            }
            return View(createViewModel);
        }

        /// <summary>
        /// Edit Store
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Edit Store</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var store = await _storeService.GetStoreEditAsync(id.Value);
            if (store == null)
            {
                return BadRequest();
            }
            return View(store);
        }
           
        /// <summary>
        /// Edit Store
        /// </summary>
        /// <param name="editViewModel">StoreViewModel</param>
        /// <returns>Index Store</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(StoreViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _storeService.StoreEditAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditStoreSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditStore").ToString();
                return View(editViewModel);
            }
            return View(editViewModel);
        }
        
        /// <summary>
        /// Delete Store
        /// </summary>
        /// <param name="id">Store id</param>
        /// <returns>Index Store</returns>
        [HttpGet]  
        [Authorize(Roles = "Admin")]  
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _storeService.DeleteStoreAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteStoreSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteStore").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}