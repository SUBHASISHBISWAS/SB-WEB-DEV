using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SwigyFoodVendor.Controllers
{
    public class HelloController : IController
    {

        public void Execute(RequestContext requestContext)
        {
            requestContext.HttpContext.Response.Write("Hello");


            _logger.Log("My Message");
        }
        ILogger _logger;
        HelloController(ILogger logger)
        {
            _logger = logger;
        }
        
    }
}