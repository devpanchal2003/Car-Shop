using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CarShop2024.Admin
{
    public partial class ViewCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        protected void BindCustomers()
        {
            StringBuilder html = new StringBuilder();
            // Assuming you have a connection string in your web.config file
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_customer", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + reader["ID"] + "</td>");
                        html.Append("<td>" + reader["FirstName"] + "</td>");
                        html.Append("<td>" + reader["LastName"] + "</td>");
                        html.Append("<td>" + reader["Email"] + "</td>");
                        html.Append("<td>" + reader["ContactNumber"] + "</td>");
                        html.Append("<td>" + reader["Gender"] + "</td>");
                        html.Append("<td>" + reader["Address"] + "</td>");
                        html.Append("<td>");
                        html.Append("<a href='UpdateCustomer.aspx?id=" + reader["ID"] + "'>Update</a>");
                        html.Append("<a href='#' onclick='confirmDelete(" + reader["ID"] + ")'>Delete</a>");
                        html.Append("</td>");
                        html.Append("</tr>");
                    }
                }
            }
            ltCustomers.Text = html.ToString();
        }

        protected void DeleteCustomer(int customerId)
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_customer WHERE ID = @CustomerId", con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Register client-side script for confirmation dialog
            string script = @"<script>
                                function confirmDelete(customerId) {
                                    if (confirm('Are you sure you want to delete this customer?')) {
                                        window.location.href = 'ViewCustomers.aspx?delete=' + customerId;
                                    }
                                }
                             </script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ConfirmDeleteScript", script);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            // Check if delete querystring parameter is present
            if (!string.IsNullOrEmpty(Request.QueryString["delete"]))
            {
                int customerId;
                if (int.TryParse(Request.QueryString["delete"], out customerId))
                {
                    // Call delete function
                    DeleteCustomer(customerId);
                    // Redirect back to the same page to refresh the GridView
                    Response.Redirect("ViewCustomers.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCustomersBySearch();
        }

        protected void BindCustomersBySearch()
        {
            StringBuilder html = new StringBuilder();
            // Assuming you have a connection string in your web.config file
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM tbl_customer WHERE FirstName LIKE @FirstName OR LastName LIKE @LastName";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FirstName", "%" + txtSearchFirstName.Text.Trim() + "%");
                    cmd.Parameters.AddWithValue("@LastName", "%" + txtSearchLastName.Text.Trim() + "%");
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + reader["ID"] + "</td>");
                        html.Append("<td>" + reader["FirstName"] + "</td>");
                        html.Append("<td>" + reader["LastName"] + "</td>");
                        html.Append("<td>" + reader["Email"] + "</td>");
                        html.Append("<td>" + reader["ContactNumber"] + "</td>");
                        html.Append("<td>" + reader["Gender"] + "</td>");
                        html.Append("<td>" + reader["Address"] + "</td>");
                        html.Append("<td>");
                        html.Append("<a href='UpdateCustomer.aspx?id=" + reader["ID"] + "'>Update</a>");
                        html.Append("<a href='#' onclick='confirmDelete(" + reader["ID"] + ")'>Delete</a>");
                        html.Append("</td>");
                        html.Append("</tr>");
                    }
                }
            }
            ltCustomers.Text = html.ToString();
        }
    }
}
