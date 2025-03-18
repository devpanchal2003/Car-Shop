using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace YourNamespace
{
    public partial class BookAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load cars into DropDownList
                LoadCars();
            }
        }

        protected void LoadCars()
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True"; // Replace with your connection string
            string query = "SELECT car_id, make, model, year FROM tbl_car_details";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCars.DataSource = reader;
                ddlCars.DataTextField = "make"; // Display car make in dropdown
                ddlCars.DataValueField = "car_id"; // Use car_id as the value
                ddlCars.DataBind();

                reader.Close();
            }

            // Add default item
            ddlCars.Items.Insert(0, new ListItem("Select Car", ""));
        }

        protected void btnBookAppointment_Click(object sender, EventArgs e)
        {
            // Retrieve user ID from session
            int userId = Convert.ToInt32(Session["UserId"]);

            if (userId == 0)
            {
                lblMessage.Text = "User session not found. Please log in again.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Visible = true;
                return;
            }

            string connectionString = "YourConnectionString"; // Replace with your connection string
            string query = "INSERT INTO tbl_appointments (user_id, preferred_time, car_id) " +
                           "VALUES (@UserId, @PreferredTime, @CarId)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@PreferredTime", DateTime.Parse(txtPreferredTime.Value));
                cmd.Parameters.AddWithValue("@CarId", ddlCars.SelectedValue);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Appointment booked successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Visible = true;
                }
                else
                {
                    lblMessage.Text = "Failed to book appointment. Please try again.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Visible = true;
                }
            }
        }
    }
}
