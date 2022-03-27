using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwigyFoodVendor.Controllers
{
    public interface ILogger
    {
        void Log(string message);
    }
}