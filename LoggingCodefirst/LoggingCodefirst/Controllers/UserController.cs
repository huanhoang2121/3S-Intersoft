using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    [ServiceFilter(typeof(AuthorizedActionFilter))]
    public class UserController : Controller
    {
        #region Private Members

        private readonly IUserService _userService;
        private readonly IStoreService _storeService;
        private readonly LocalizationService<UserResource> _localizer;

        #endregion
        
        #region Constructors
        
        public UserController(
            IUserService userService, 
            IStoreService storeService, 
            LocalizationService<UserResource> localizer)
        {
            _localizer = localizer;
            _userService = userService;
            _storeService = storeService;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Index User Get Function
        /// </summary>
        /// <returns>Index User</returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listuser = await _userService.GetListUserAsync();
            return View(listuser);
        }

        /// <summary>
        /// Create User Get Function
        /// </summary>
        /// <returns>Create User</returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName");
            return View();
        }
        
        /// <summary>
        /// Create User Post Function
        /// </summary>
        /// <param name="createViewModel"></param>
        /// <returns>Index User</returns>
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.CreateUserAsync(createViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateUserSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateUser").ToString();
                ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName", createViewModel.StoreId);
                return View(createViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName", createViewModel.StoreId);
            return View(createViewModel);
        }
        
        /// <summary>
        /// Edit User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit User</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetUserEditAsync(id.Value);
            if (user == null)
            {
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName", user.StoreId);
            return View(user);
        }
        
        /// <summary>
        /// Edit User Post Function
        /// </summary>
        /// <param name="editViewModel"></param>
        /// <returns>Index User</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.EditUserAsync(editViewModel))
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditUserSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditUser").ToString();
                ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName", editViewModel.StoreId);
                return View(editViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores(), "Id", "StoreName", editViewModel.StoreId);
            return View(editViewModel);
        }
        
        /// <summary>
        /// ChangePassword User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ChangePassword</returns>
        [HttpGet]
        public async Task<IActionResult> ChangePassword(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetChangePasswordAsync(id.Value);
            if (user == null)
            {
                return BadRequest();
            }
            return PartialView("_ChangePasswordPartial",user);  
        }
        
        /// <summary>
        /// ChangePassword User Post Function
        /// </summary>
        /// <param name="changePasswordModel"></param>
        /// <returns>Index User</returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel changePasswordModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ChangePasswordAsync(changePasswordModel);
                if (user)
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_ChangePasswordSuccess").ToString();
                    return PartialView("_ChangePasswordPartial",changePasswordModel); 
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_ChangePassword").ToString();
                return PartialView("_ChangePasswordPartial",changePasswordModel); 
            }
            return PartialView("_ChangePasswordPartial",changePasswordModel);  
        }
        
        /// <summary>
        /// Delete User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Index User</returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (await _userService.DeleteUserAsync(id.Value))
            {
                TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_DeleteUserSuccess").ToString();
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_DeleteUser").ToString();
            return RedirectToAction(nameof(Index));
        }
        
        #endregion
        
    }//end of class
}