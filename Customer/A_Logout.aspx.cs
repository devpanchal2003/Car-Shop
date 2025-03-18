using System;

namespace CarShop2024.Admin
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear the session
            Session.Clear();
            // Redirect to the login page
            Response.Redirect("AdminLogin.aspx");
        }
    }
}
