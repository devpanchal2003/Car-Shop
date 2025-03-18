using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check if username and password are correct
            if (username == "admin" && password == "admin")
            {
                Session["AdminUsername"] = username;
                Response.Redirect("AdminDashboard.aspx");
            }
            else
            {
                Label1.Text = "Invalid username or password.";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}