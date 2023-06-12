using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1_ViewState_Demo
{


    public partial class About : Page
    {
        int ClicksCount = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TextBox1.Text = "0";
            }

            Response.Write("Number of Applications: " + Application["TotalApplications"]);
            Response.Write("<br/>");

            Response.Write("Number of Users Online: " + Application["TotalUserSessions"]);
        }

        protected void Buttonl_Click(object sender, EventArgs e)
        {
            if (ViewState["Clicks"]!=null)
            {
                ClicksCount = (int)ViewState["Clicks"] + 1;
            }
            TextBox1.Text = ClicksCount.ToString();
            ViewState["Clicks"] = ClicksCount;
        }

    }

}