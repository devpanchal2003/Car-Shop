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
    public partial class S_Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] != null)
            {
                Response.Redirect("S_Login.aspx");
            }
        }
        protected void submit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string email = reg_email.Text.Trim();
                string password = reg_password.Text.Trim();
                string confirmPassword = reg_confirm_password.Text.Trim();

                // Validate fields
                if (!ValidateFields(email, password, confirmPassword))
                {
                    return;
                }

                // Hash the password
                string hashedPassword = HashedPassword(password);

                // Insert user data into database
                string query = "INSERT INTO tbl_Staff ( Email, PasswordHash) VALUES (@Email, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("S_Login.aspx");
                }


            }
        }

        private bool ValidateFields(string email,string password, string confirmPassword)
        {

            // Validate email
            if (string.IsNullOrEmpty(email))
            {
                Label1.Text = "Error: Please enter your Email.";
                return false;
            }
            else if (!IsValidEmail(email))
            {
                Label1.Text = "Error: Please enter a valid Email address.";
                return false;
            }

            if (string.IsNullOrEmpty(password))
            {
                Label1.Text = "Error: Please enter a Password.";
                return false;
            }

            // Validate confirm password
            if (string.IsNullOrEmpty(confirmPassword))
            {
                Label1.Text = "Error: Please confirm your Password.";
                return false;
            }

            // Check if password and confirm password match
            if (password != confirmPassword)
            {
                Label1.Text = "Error: Passwords do not match.";
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private string HashedPassword(string hashedpassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashedpassword));
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