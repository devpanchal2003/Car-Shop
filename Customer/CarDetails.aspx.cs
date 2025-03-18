using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CarShop2024.Customer
{
    public partial class CarDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCars();
            }
        }

        protected void BindCars()
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            string query = "SELECT Pid, Make, Model, Year, Images, Price, Color, Engine_Type, Transmission_Type, Hors_Power, Features, Availability FROM tbl_product_details";

            StringBuilder html = new StringBuilder();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int pid = Convert.ToInt32(reader["Pid"]);
                        string make = reader["Make"].ToString();
                        string model = reader["Model"].ToString();
                        int year = Convert.ToInt32(reader["Year"]);
                        string images = reader["Images"].ToString();
                        decimal price = Convert.ToDecimal(reader["Price"]);
                        string color = reader["Color"].ToString();
                        string engineType = reader["Engine_Type"].ToString();
                        string transmissionType = reader["Transmission_Type"].ToString();
                        int horsePower = Convert.ToInt32(reader["Hors_Power"]);
                        string features = reader["Features"].ToString();
                        string availability = reader["Availability"].ToString();
                        
                        html.Append("<div class='car-card'>");
                        html.Append("<img src='~/Images/Cars/" + images + "' alt='" + make + " " + model + "' />");
                        html.Append("<h3>" + make + " " + model + " " + year + "</h3>");
                        html.Append("<p><strong>Price:</strong> $" + price + "</p>");
                        html.Append("<p><strong>Color:</strong> " + color + "</p>");
                        html.Append("<p><strong>Engine Type:</strong> " + engineType + "</p>");
                        html.Append("<p><strong>Transmission Type:</strong> " + transmissionType + "</p>");
                        html.Append("<p><strong>Horse Power:</strong> " + horsePower + "</p>");
                        html.Append("<p><strong>Features:</strong> " + features + "</p>");
                        html.Append("<p><strong>Availability:</strong> " + availability + "</p>");
                        html.Append("<button class='buy-btn' onclick='buyNow(" + pid + ")'>Book Testdrive Now</button>");
                        Response.Redirect("BookTestdrive.aspx");
                        html.Append("</div>");
                    }
                    connection.Close();
                }
            }

            ltCars.Text = html.ToString();
        }
    }
}
