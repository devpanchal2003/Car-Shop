using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace CarShop2024.Customer
{
    public partial class C_Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["Userid"] != null)
            {
                Response.Redirect("C_Dashboard.aspx");
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
                    string qry = "SELECT ID FROM tbl_customer WHERE Email=@Email AND PasswordHash=@Password";
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            int id = Convert.ToInt32(result);
                            Session["Userid"] = id;
                            // Redirect with user ID in URL
                            Response.Redirect($"C_Dashboard.aspx?UserId={id}");
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
