using log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ExpoCenter.Mvc.Filters
{
    public class ErrorLogFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.Exception != null)
            {
                var controller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                var loggerName = $"{controller}Controller.{action}";
                               
                //LogManager.GetLogger(loggerName).Error(filterContext.Exception.Message, filterContext.Exception);
            }
        }
    }
}