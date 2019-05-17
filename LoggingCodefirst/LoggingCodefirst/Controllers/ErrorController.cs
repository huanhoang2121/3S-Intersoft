using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class ErrorController : Controller
    {
        
        #region Public Methods

        /// <summary>
        /// Error 400
        /// </summary>
        /// <returns>Error 400 view</returns>
        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View();
        }
        
        /// <summary>
        /// Error 401
        /// </summary>
        /// <returns>Error 401 view</returns>
        [Route("Error/401")]
        public IActionResult Error401()
        {
            return View();
        }
        
        
        /// <summary>
        /// Error 403
        /// </summary>
        /// <returns>Error 403 view</returns>
        [Route("Error/403")]
        public IActionResult Error403()
        {
            return View();
        }
        
        /// <summary>
        /// Error 404
        /// </summary>
        /// <returns>Error 404 view</returns>
        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }
        
        /// <summary>
        /// Error 405
        /// </summary>
        /// <returns>Error 405 view</returns>
        [Route("Error/405")]
        public IActionResult Error405()
        {
            return View();
        }
        
        /// <summary>
        /// Error 500
        /// </summary>
        /// <returns>Error 500 view</returns>
        [Route("Error/500")]
        public IActionResult Error500()
        {
            return View();
        }        
        
        #endregion

    }
}