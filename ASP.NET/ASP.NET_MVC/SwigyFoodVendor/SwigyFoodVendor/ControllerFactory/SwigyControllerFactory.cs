using StructureMap;
using SwigyFoodVendor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SwigyFoodVendor.ControllerFactory
{
    public class SwigyControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, 
            Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;


            //return Activator.CreateInstance(controllerType, new SqlServerLogger())
            //   as IController;
        }
    }
}