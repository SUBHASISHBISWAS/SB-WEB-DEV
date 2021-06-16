using SwigyFoodVendor.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwigyFoodVendor.Services
{
    public class SqlServerLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}