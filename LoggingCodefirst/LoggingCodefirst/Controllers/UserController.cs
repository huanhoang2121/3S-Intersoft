using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace LoggingCodefirst.Controllers
{
    public class UserController : Controller
    {
        #region Private Members

        private readonly IUserService _userService;
        private readonly IStoreService _storeService;
        private readonly IStringLocalizer<UserController> _localizer;

        #endregion
        
        #region Constructors
        
        public UserController(
            IUserService userService, 
            IStoreService storeService, 
            IStringLocalizer<UserController> localizer)
        {
            _localizer = localizer;
            _userService = userService;
            _storeService = storeService;
        }

        #endregion

        #region Public Methods
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userService.GetListUserAsync();
            return View(listuser);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName");
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.CreateUserAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer["Create successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
                return View(createViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
            return View(createViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserEditAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", user.StoreId);
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.EditUserAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer["Edit successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
                return View(editViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
            return View(editViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetChangePasswordAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.ChangePasswordAsync(changePasswordModel))
                {
                    TempData["SuccessMessage"] = _localizer["Change password successfully!"].ToString();
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = _localizer["Change password fail!"].ToString();
                return View(changePasswordModel);
            }
            return View(changePasswordModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (await _userService.DeleteUserAsync(id))
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