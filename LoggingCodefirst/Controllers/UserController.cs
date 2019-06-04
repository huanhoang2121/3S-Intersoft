using System.Threading.Tasks;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoggingCodefirst.Controllers
{  
    [Authorize(Roles = "Admin")]    
    public class UserController : Controller
    {
        #region Private Members

        private readonly IUserService _userService;
        private readonly IStoreService _storeService;
        private readonly IRoleService _roleService;
        private readonly ILocalizationService<UserResource> _localizer;

        #endregion
        
        #region Constructors
        
        public UserController(
            IUserService userService, 
            IStoreService storeService, 
            IRoleService roleService,
            ILocalizationService<UserResource> localizer)
        {
            _userService = userService;
            _storeService = storeService;
            _roleService = roleService;
            _localizer = localizer;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Index User
        /// </summary>
        /// <returns>Index User</returns>
        [HttpGet]
        public IActionResult Index()
        {
            var listuser = _userService.GetUsers();
            return View(listuser);
        }

        /// <summary>
        /// Create User
        /// </summary>
        /// <returns>Create User</returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName");
            ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName");
            return View();
        }
        
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="createViewModel">UserViewModel</param>
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
                ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName", createViewModel.StoreId);
                ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName", createViewModel.RoleId);
                return View(createViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName", createViewModel.StoreId);
            ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName", createViewModel.RoleId);
            return View(createViewModel);
        }
        
        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>Edit User</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var editViewModel = await _userService.GetUserEditAsync(id.Value);
            if (editViewModel == null)
            {
                return BadRequest();
            }
            ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName", editViewModel.StoreId);
            ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName", editViewModel.RoleId);
            return View(editViewModel);
        }
        
        /// <summary>
        /// Edit User
        /// </summary>
        /// <param name="editViewModel">UserEditViewModel</param>
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
                ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName", editViewModel.StoreId);
                ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName", editViewModel.RoleId);
                return View(editViewModel);
            }
            ViewBag.StoreId = new SelectList(_storeService.GetStores(), "Id", "StoreName", editViewModel.StoreId);
            ViewBag.RoleId = new SelectList(_roleService.GetRoles(), "Id", "RoleName", editViewModel.RoleId);
            return View(editViewModel);
        }
        
        /// <summary>
        /// ChangePassword User
        /// </summary>
        /// <param name="id">User id</param>
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
        /// ChangePassword User
        /// </summary>
        /// <param name="changePasswordModel">UserChangePasswordViewModel</param>
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
        /// Delete User
        /// </summary>
        /// <param name="id">User id</param>
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