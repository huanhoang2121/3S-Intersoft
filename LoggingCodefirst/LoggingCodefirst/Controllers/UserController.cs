using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using LoggingCodefirst.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{
    public class UserController : Controller
    {
        #region Private Members

        private readonly IUserService _userService;
        private readonly IStoreService _storeService;
        private readonly LocalizationService _localizer;

        #endregion
        
        #region Constructors
        
        public UserController(
            IUserService userService, 
            IStoreService storeService, 
            LocalizationService localizer)
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
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName");
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
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_CreateSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_CreateFail").ToString();
                ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
                return View(createViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", createViewModel.StoreId);
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
            var user = await _userService.GetUserEditAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", user.StoreId);
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
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_EditSuccess").ToString();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_EditFail").ToString();
                ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
                return View(editViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.Stores, "Id", "StoreName", editViewModel.StoreId);
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
            var user = await _userService.GetChangePasswordAsync(id);
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
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_ChangePasswordFail").ToString();
                return PartialView("_ChangePasswordPartial",changePasswordModel); 
            }
            return PartialView("_ChangePasswordPartial",changePasswordModel);  
        }
        
        /// <summary>
        /// ChangeEmail User Get Function
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ChangeEmail</returns>
        [HttpGet]
        public async Task<IActionResult> ChangeEmail(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = await _userService.GetChangeEmailAsync(id);
            if (user == null)
            {
                return BadRequest();
            }
            return PartialView("_ChangeEmailPartial",user);  
        }
        
        /// <summary>
        /// ChangeEmail User Post Function
        /// </summary>
        /// <param name="changeEmailViewModel"></param>
        /// <returns>Index User</returns>
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(UserChangeEmailViewModel changeEmailViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.ChangeEmailAsync(changeEmailViewModel);
                if (user)
                {
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_ChangeEmailSuccess").ToString();
                    return PartialView("_ChangeEmailPartial",changeEmailViewModel); 
                }
                TempData["ErrorMessage"] = _localizer.GetLocalizedString("err_ChangeEmailFail").ToString();
                return PartialView("_ChangeEmailPartial",changeEmailViewModel); 
            }
            return PartialView("_ChangeEmailPartial",changeEmailViewModel);  
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
            if (await _userService.DeleteUserAsync(id))
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