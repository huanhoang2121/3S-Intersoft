using Microsoft.AspNetCore.Mvc;

namespace LoggingCodefirst.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/400")]
        public IActionResult Error400()
        {
            return View();
        }[Route("Error/401")]
        public IActionResult Error401()
        {
            return View();
        }
        [Route("Error/403")]
        public IActionResult Error403()
        {
            return View();
        }
        [Route("Error/404")]
        public IActionResult Error404()
        {
            return View();
        }
        [Route("Error/405")]
        public IActionResult Error405()
        {
            return View();
        }
        [Route("Error/500")]
        public IActionResult Error500()
        {
            return View();
        }
    }
}