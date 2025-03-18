using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Staff
{
    public partial class S_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Staffid"] != null)
            {
                Response.Redirect("StaffHomePage.aspx");
            }
        }

        protected void login_submit_Click(object sender, EventArgs e)
        {
            string email = reg_email.Text.Trim();
            string password = hashpassword(reg_password.Text);

            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string qry = "SELECT ID FROM tbl_Staff WHERE Email=@Email AND PasswordHash=@Password";
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int id = Convert.ToInt32(result);
                            Session["Staffid"] = id;
                            Response.Redirect("StaffHomePage.aspx");
                        }
                        else
                        {
                            Label1.Text = "Invalid Email or Password.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
            }
        }

        private string hashpassword(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}