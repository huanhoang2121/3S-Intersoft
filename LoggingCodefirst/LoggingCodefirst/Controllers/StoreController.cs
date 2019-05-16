using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    [ServiceFilter(typeof(AuthorizedActionFilter))]
    public class StoreController : Controller
    {
        #region Private Members

        private readonly IStoreService _storeService;
        private readonly LocalizationService<ViewResource> _localizer;

        #endregion
        
        #region Constructors
        
        public StoreController(
            IStoreService storeService, 
            LocalizationService<ViewResource> localizer)
        {
            _localizer = localizer;
            _storeService = storeService;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Index Store Get Function
        /// </summary>
        /// <returns>Index Store</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stores = await _storeService.GetListStoreAsync();
            return View(stores);
        }

        /// <summary>
        /// Create Store Get Function
        /// </summary>
        /// <returns>Create Store</returns>
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        /// <summary>
        /// Create Store Post Function
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Index Store</returns>
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
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                return View(createViewModel);
            }
            return View(createViewModel);
        }

        /// <summary>
        /// Edit Store Get Function
        /// </summary>
        /// <param name="id"></param>
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
        /// Edit Store Post Function
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Index Store</returns>
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
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                return View(editViewModel);
            }
            return View(editViewModel);
        }
        
        /// <summary>
        /// Delete Store Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Index Store</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            if (await _storeService.DeleteStoreAsync(id.Value))
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