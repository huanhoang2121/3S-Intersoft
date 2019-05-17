using System.Threading.Tasks;
using LoggingCodefirst.Filters;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class AccountController : Controller
    {
        #region Private Members
        
        private readonly IUserService _userService;
        private readonly LocalizationService<UserResource> _localizer;
         
        #endregion
        
        #region Constructors
        
        public AccountController(IUserService userService, LocalizationService<UserResource> localizer)
        {
            _userService = userService;
            _localizer = localizer;
        }
        
        #endregion

        #region Public Methods
        
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="returnUrl">returnUrl</param>
        /// <returns>Login form</returns>
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != null) return View();
            ViewBag.ReturnUrl = AuthorizedActionFilter.Returnurl;
            return View();
        }
        
        /// <summary>
        /// Post Login User
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>view</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = _userService.Login(loginViewModel);
                if (isValidUser)
                {
                    var user = await _userService.GetUserAsync(loginViewModel.Email);
                    HttpContext.Session.SetString("userid", user.Id.ToString());
                    HttpContext.Session.SetString("username", user.Fullname);
                    HttpContext.Session.SetString("imagepath", user.ImagePath);
                        
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_LoginSuccess").ToString();
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_Login");
                return View();
            }
            return View(loginViewModel);
        }
        
        /// <summary>
        /// Logout User
        /// </summary>
        /// <returns>Home Index</returns>
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index", "Home");
        }
        
        #endregion
        
    }//end of class
}