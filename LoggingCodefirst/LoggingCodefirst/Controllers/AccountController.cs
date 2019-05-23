using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LoggingCodefirst.Resources;
using LoggingCodefirst.Services;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Private Members
        
        private readonly IUserService _userService;
        private readonly LocalizationService<UserResource> _localizer;
         
        #endregion
        
        #region Constructors
        
        public AccountController(
            IUserService userService, 
            LocalizationService<UserResource> localizer)
        {
            _userService = userService;
            _localizer = localizer;
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
                if (await _userService.Login(loginViewModel))
                {
                    var user = await _userService.GetUserAsync(loginViewModel.Email);
                    HttpContext.Session.SetString("userid", user.Id.ToString());
                    HttpContext.Session.SetString("username", user.Fullname);
                    HttpContext.Session.SetString("imagepath", user.ImagePath);

                    // create claims
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role)
                    };

                    // create identity
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    // create principal
                    var principal = new ClaimsPrincipal(identity);

                    // sign-in
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties());
                
                    TempData["SuccessMessage"] = _localizer.GetLocalizedString("msg_LoginSuccess").ToString();
                    return Redirect(loginViewModel.RequestPath ?? "/");
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
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }
        
        #endregion
        
    }//end of class
}