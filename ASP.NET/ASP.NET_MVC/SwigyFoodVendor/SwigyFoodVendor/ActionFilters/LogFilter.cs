using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SwigyFoodVendor.ActionFilters
{
    public class LogAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("In Action Excuting", filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("In Action Executed", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("In Result Excuting", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("In Result Executed", filterContext.RouteData);
        }

        void Log(string stageName, RouteData routeData)
        {
            Debug.WriteLine(
            String.Format("{0}::{1} - {2}",
            routeData.Values["control1er"],
            routeData.Values["action"],
            stageName));
        }



    }
}