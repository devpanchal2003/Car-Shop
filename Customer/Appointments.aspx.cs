using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CarShop2024.Customer
{
    public partial class Appointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAppointments();
            }
        }

        private void LoadAppointments()
        {
            StringBuilder html = new StringBuilder();
            string connectionString = "YourConnectionString";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_appointments", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        html.Append("<tr>");
                        html.Append("<td>" + reader["AppointmentID"] + "</td>");
                        html.Append("<td>" + reader["CustomerName"] + "</td>");
                        html.Append("<td>" + reader["AppointmentDate"] + "</td>");
                        html.Append("<td>" + reader["CarMake"] + "</td>");
                        html.Append("<td>" + reader["CarModel"] + "</td>");
                        html.Append("<td>" + reader["Status"] + "</td>");
                        html.Append("<td>");
                        html.Append("<a href='AcceptAppointment.aspx?id=" + reader["AppointmentID"] + "'>Accept</a>");
                        html.Append("<a href='RejectAppointment.aspx?id=" + reader["AppointmentID"] + "'>Reject</a>");
                        html.Append("</td>");
                        html.Append("</tr>");
                    }
                }
            }
            
            ltAppointments.Text = html.ToString();
        }
    }
}
