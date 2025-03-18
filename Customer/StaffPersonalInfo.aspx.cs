using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace CarShop2024.Staff
{
    public partial class StaffPersonalInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load staff personal information if available
                LoadStaffInfo();
            }
        }

        private void LoadStaffInfo()
        {
            // Fetch staff personal information from database and populate the fields
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            string staffEmail = Session["StaffEmail"].ToString(); // Assuming you have a session variable storing the staff email

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM StaffPersonalInfo WHERE StaffID = (SELECT ID FROM tbl_staff WHERE Email = @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", staffEmail);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtLastName.Text = reader["LastName"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                            ddlGender.SelectedValue = reader["Gender"].ToString();
                            txtContactNumber.Text = reader["ContactNumber"].ToString();
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Update or insert staff personal information
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            string staffEmail = Session["StaffEmail"].ToString(); // Assuming you have a session variable storing the staff email

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Check if staff personal information already exists
                string checkQuery = "SELECT COUNT(*) FROM StaffPersonalInfo WHERE StaffID = (SELECT ID FROM tbl_staff WHERE Email = @Email)";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", staffEmail);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        // Update existing record
                        string updateQuery = "UPDATE StaffPersonalInfo SET FirstName = @FirstName, LastName = @LastName, Address = @Address, Gender = @Gender, ContactNumber = @ContactNumber WHERE StaffID = (SELECT ID FROM tbl_staff WHERE Email = @Email)";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            updateCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            updateCmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            updateCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                            updateCmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                            updateCmd.Parameters.AddWithValue("@Email", staffEmail);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert new record
                        string insertQuery = "INSERT INTO StaffPersonalInfo (StaffID, FirstName, LastName, Address, Gender, ContactNumber) VALUES ((SELECT ID FROM tbl_staff WHERE Email = @Email), @FirstName, @LastName, @Address, @Gender, @ContactNumber)";
                        using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            insertCmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            insertCmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                            insertCmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                            insertCmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                            insertCmd.Parameters.AddWithValue("@Email", staffEmail);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            // Show success message or redirect to another page
            // Response.Redirect("AnotherPage.aspx");
        }
    }
}
