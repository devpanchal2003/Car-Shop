using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CarShop2024
{
    public partial class C_Registration: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Userid"] != null)
            {
                Response.Redirect("C_Login.aspx");
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string firstName = reg_firstname.Text.Trim();
                string lastName = reg_lastname.Text.Trim();
                string email = reg_email.Text.Trim();
                string contact = reg_contact.Text.Trim();
                string gender = rbmale.Checked ? "Male" : "Female";
                string address = reg_address.Text.Trim();
                string password = reg_password.Text.Trim();
                string confirmPassword = reg_confirm_password.Text.Trim();

                // Validate fields
                if (!ValidateFields(firstName, lastName, email, contact, address, password, confirmPassword))
                {
                    return;
                }

                // Hash the password
                string hashedPassword = HashedPassword(password);

                // Insert user data into database
                string query = "INSERT INTO tbl_customer (FirstName, LastName, Email, ContactNumber, Gender, Address, PasswordHash) VALUES (@FirstName, @LastName, @Email, @Contact, @Gender, @Address, @Password)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("C_Login.aspx");
                }


            }
        }

        private bool ValidateFields(string firstName, string lastName, string email, string contact, string address, string password, string confirmPassword)
        {
            // Validate first name
            if (string.IsNullOrEmpty(firstName))
            {
                Label1.Text = "Error: Please enter your First Name.";
                return false;
            }
            else if (firstName.Any(char.IsDigit))
            {
                Label1.Text = "Error: First Name cannot contain digits.";
                return false;
            }
            else if (firstName.Any(char.IsSymbol))
            {
                Label1.Text = "Error: First Name cannot contain special characters.";
                return false;
            }

            // Validate last name
            if (string.IsNullOrEmpty(lastName))
            {
                Label1.Text = "Error: Please enter your Last Name.";
                return false;
            }
            else if (lastName.Any(char.IsDigit))
            {
                Label1.Text = "Error: Last Name cannot contain digits.";
                return false;
            }
            else if (lastName.Any(char.IsSymbol))
            {
                Label1.Text = "Error: Last Name cannot contain special characters.";
                return false;
            }

            // Validate email
            if (string.IsNullOrEmpty(email))
            {
                Label1.Text = "Error: Please enter your Email.";
                return false;
            }
            else if (!email.EndsWith("@gmail.com"))
            {
                Label1.Text = "Error: Email should end with @gmail.com.";
                return false;
            }

            // Validate contact number
            if (string.IsNullOrEmpty(contact))
            {
                Label1.Text = "Error: Please enter your Contact Number.";
                return false;
            }
            else if (contact.Length != 10 || !contact.All(char.IsDigit))
            {
                Label1.Text = "Error: Contact Number should be a 10-digit number.";
                return false;
            }

            // Validate address
            if (string.IsNullOrEmpty(address))
            {
                Label1.Text = "Error: Please enter your Address.";
                return false;
            }

            // Validate password
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

