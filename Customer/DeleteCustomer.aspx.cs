using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Customer
{
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCustomerId.Text))
            {
                int customerId;
                if (int.TryParse(txtCustomerId.Text, out customerId))
                {
                    string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand("DELETE FROM tbl_customer WHERE ID = @CustomerId", con))
                        {
                            cmd.Parameters.AddWithValue("@CustomerId", customerId);
                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                lblMessage.Text = "Customer deleted successfully.";
                                lblMessage.CssClass = "success-message";
                            }
                            else
                            {
                                lblMessage.Text = "Customer with the provided ID does not exist.";
                                lblMessage.CssClass = "error-message";
                            }
                            lblMessage.Visible = true;
                        }
                    }
                }
                else
                {
                    lblMessage.Text = "Please enter a valid customer ID.";
                    lblMessage.CssClass = "error-message";
                    lblMessage.Visible = true;
                }
            }
            else
            {
                lblMessage.Text = "Please enter a customer ID.";
                lblMessage.CssClass = "error-message";
                lblMessage.Visible = true;
            }
        }
    }
}