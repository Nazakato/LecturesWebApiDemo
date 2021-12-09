using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiDemo.Filters
{
    public class AddTimestampActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting " + filterContext.Controller.ToString() + filterContext.ActionDescriptor.DisplayName);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted " + filterContext.Controller.ToString() + filterContext.ActionDescriptor.DisplayName);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting " + filterContext.Controller.ToString() + filterContext.ActionDescriptor.DisplayName);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted " + filterContext.Controller.ToString() + filterContext.ActionDescriptor.DisplayName);
        }

        private void Log(string message)
        {
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}
