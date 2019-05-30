using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoggingCodefirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Serilog;

namespace LoggingCodefirst.Controllers
{
    public class HomeController : Controller
    {
        
        #region Public Methods

        /// <summary>
        /// Home Index
        /// </summary>
        /// <returns>Home Index</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Home Privacy
        /// </summary>
        /// <returns>Home Privacy</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Home Error
        /// </summary>
        /// <returns>Home Error</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        /// <summary>
        /// Set Culture Function
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public IActionResult SetCulture(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
        
            return LocalRedirect(returnUrl);
        }
        
        #endregion
    }
}