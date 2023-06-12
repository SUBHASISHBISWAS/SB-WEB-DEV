using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _5_Controls_ASP.NET
{
    public partial class DropDownDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (var con = new SqlConnection(CS))
                {
                    var cmd = new SqlCommand("Select CityId, CityName, Country from tblCity", con);
                    con.Open();
                    var rdr = cmd.ExecuteReader();
                    DropDownList1.DataTextField = "CityName";
                    DropDownList1.DataValueField = "CityId";
                    DropDownList1.DataSource = rdr;
                    DropDownList1.DataBind();
                }
            }
            
        }
    }
}