using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace _1_ViewState_Demo
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Application["TotalApplications"] = 0;
            Application["TotalUserSessions"] = 0;
        }

        void Application_End(object sender, EventArgs e)
        {

        }
        void Session_Start(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
        }
    }
}