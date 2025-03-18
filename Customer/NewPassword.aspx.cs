using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace CarShop2024.Customer
{
    public partial class NewPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string email = Session["Email"].ToString();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword == confirmPassword)
            {
                string hashedPassword = HashedPassword(newPassword);

                string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string updateQuery = "UPDATE tbl_customer SET PasswordHash = @PasswordHash WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        command.Parameters.AddWithValue("@Email", email);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                txterror.Text = "Password changed successfully.";
                                Response.Redirect("C_Login.aspx");
                            }
                            else
                            {
                                txterror.Text = "Failed to change password. Please try again.";
                            }
                        }
                        catch (Exception ex)
                        {
                            txterror.Text = "An error occurred: " + ex.Message;
                        }
                    }
                }
            }
            else
            {
                txterror.Text = "New password and confirm password do not match.";
            }
        }

        private string HashedPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
