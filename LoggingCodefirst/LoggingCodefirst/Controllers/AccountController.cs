using System.Threading.Tasks;
using LoggingCodefirst.Authentication;
using LoggingCodefirst.Interface;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LoggingCodefirst.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Private Members
        
        private readonly IUserService _userService;
        private readonly LocalizationService<UserResource> _localizer;        
        private readonly IUserAuthenticationService _authenticationService;
         
        #endregion
        
        #region Constructors
        
        public AccountController(
            IUserService userService, 
            LocalizationService<UserResource> localizer, IUserAuthenticationService authenticationService)
        {
            _userService = userService;
            _localizer = localizer;
            _authenticationService = authenticationService;
        }
        
        #endregion

        #region Public Methods
        
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="requestPath">returnUrl</param>
        /// <returns>Login form</returns>
        [HttpGet]
        public IActionResult Login(string requestPath)
        {
            ViewBag.RequestPath = requestPath ?? "/";
//            Log.Information("In the Login!");
            return View();
        }
        
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="loginViewModel">LoginViewModel</param>
        /// <returns>view</returns>
        [HttpPost]
        [AllowAnonymous]  
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _userService.LoginAsync(loginViewModel))
                {
                    var user = await _userService.GetUserByEmailAsync(loginViewModel.Email);
                    
                    await _authenticationService.SignIn(user, loginViewModel.Rememberme);
                    
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_LoginSuccess").ToString();
                    return Redirect(loginViewModel.RequestPath ?? "/");
                }     
                ViewData["ErrorMessage"] = _localizer.GetLocalizedString("err_Login");
                return View(loginViewModel);  
            }
            return View(loginViewModel);
        }
        
        /// <summary>
        /// Logout User
        /// </summary>
        /// <returns>Home Index</returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        #endregion
        
    }//end of class
}