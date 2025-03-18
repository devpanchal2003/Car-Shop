using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Staff
{
    public partial class StaffHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if staff member is logged in, if not, redirect to login page
                if (Session["Staffid"] == null)
                {
                    Response.Redirect("S_Login.aspx");
                }
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Redirect to the ChangePassword page
            Response.Redirect("S_ChangePassword.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("S_Logout.aspx");
        }
    }
}