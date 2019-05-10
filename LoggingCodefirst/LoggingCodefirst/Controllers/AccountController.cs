using System.Threading.Tasks;
using LoggingCodefirst.DependencyInjection.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class AccountController : Controller
    {
        #region Private Members
        
        private readonly IUserService _userService;
        private readonly LocalizationService _localizer;
         
        #endregion
        
        #region Constructors
        
        public AccountController(IUserService userService, LocalizationService localizer)
        {
            _userService = userService;
            _localizer = localizer;
        }
        
        #endregion

        #region Public Methods

        /// <summary>
        /// Get Login User Function
        /// </summary>
        /// <returns>User Login</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        /// <summary>
        /// Post Login User Function
        /// </summary>
        /// <returns>User Index</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var isValidUser = _userService.Login(loginViewModel);
                if (isValidUser)
                {
                    var user = await _userService.GetUserNameAsync(loginViewModel.Email);
                    HttpContext.Session.SetString("userid", user.Id.ToString());
                    HttpContext.Session.SetString("username", user.Fullname);
                        
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("Login successfully!").ToString();
                    return RedirectToAction("Index", "User");
                }
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("Login fail! Email or password incorrect!");
                return View();
            }
            return View(loginViewModel);
        }
        
        /// <summary>
        /// Logout User Function
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