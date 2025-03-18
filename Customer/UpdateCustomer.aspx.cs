using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Customer
{
    public partial class UpdateCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the form with existing customer details if it's a postback
                if (Request.QueryString["id"] != null)
                {
                    int customerId = Convert.ToInt32(Request.QueryString["id"]);
                    PopulateCustomerDetails(customerId);
                }
            }
        }

        protected void PopulateCustomerDetails(int customerId)
        {
            // Retrieve customer details from the database and populate the form
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_customer WHERE ID = @CustomerId", con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtContactNumber.Text = reader["ContactNumber"].ToString();
                        ddlGender.SelectedValue = reader["Gender"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                int customerId = Convert.ToInt32(Request.QueryString["id"]);
                string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE tbl_customer SET FirstName = @FirstName, LastName = @LastName, Email = @Email, ContactNumber = @ContactNumber, Gender = @Gender, Address = @Address WHERE ID = @CustomerId", con))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text);
                        cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Response.Redirect("ViewCustomers.aspx");
            }
        }
    }
}
