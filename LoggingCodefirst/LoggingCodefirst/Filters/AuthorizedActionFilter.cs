using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoggingCodefirst.Filters
{
    public class AuthorizedActionFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _accessor;
        
        public AuthorizedActionFilter(IHttpContextAccessor accessor) {
            _accessor = accessor;
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            var httpContext = _accessor.HttpContext;
            if (httpContext.Session.GetString("username") == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }

//        [ServiceFilter(typeof(SampleActionFilter))]
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
        }
    }
}