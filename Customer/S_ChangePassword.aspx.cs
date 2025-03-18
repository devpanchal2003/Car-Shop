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
    public partial class S_ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if staff member is logged in, if not, redirect to login page
                if (Session["StaffId"] == null)
                {
                    Response.Redirect("S_Login.aspx");
                }
            }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmNewPassword = txtConfirmNewPassword.Text.Trim();

            // Validate fields
            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmNewPassword))
            {
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                lblMessage.Text = "New Password and Confirm New Password do not match.";
                return;
            }

            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";

            // Check if current password is correct
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tbl_staff WHERE ID=@StaffId AND PasswordHash=@CurrentPassword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", Session["StaffId"]);
                    cmd.Parameters.AddWithValue("@CurrentPassword", HashedPassword(currentPassword));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            lblMessage.Text = "Current Password is incorrect.";
                            return;
                        }
                    }
                }

                // Update password
                query = "UPDATE tbl_staff SET PasswordHash=@NewPassword WHERE ID=@StaffId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NewPassword", HashedPassword(newPassword));
                    cmd.Parameters.AddWithValue("@StaffId", Session["StaffId"]);

                    cmd.ExecuteNonQuery();
                }

                lblMessage.Text = "Password changed successfully.";
                Response.Redirect("StaffHomePage.aspx");
            }
        }
        private string HashedPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
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