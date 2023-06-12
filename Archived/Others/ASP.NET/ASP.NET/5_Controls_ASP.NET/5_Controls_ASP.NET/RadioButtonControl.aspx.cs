using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5_Controls_ASP.NET
{
    public partial class RadioButtonControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Buttonl_Click(object sender, EventArgs e)
        {
            if (MaleRadioButton.Checked == true)
            {
                Response.Write("Your Gender is " + MaleRadioButton.Text);
            }
        }

        protected void MaleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("Male Button Selected");
        }
    }
}