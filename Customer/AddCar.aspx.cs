using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;

namespace CarShop2024.Customer
{
    public partial class AddCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            string make = txtMake.Text;
            string model = txtModel.Text;
            string year = txtYear.Text;
            string price = txtPrice.Text;
            string color = txtColor.Text;
            string engineType = ddlEngineType.SelectedValue;
            string transmissionType = ddlTransmissionType.SelectedValue;
            string horsePower = txtHorsePower.Text;
            string features = txtFeatures.Text;
            bool availability = chkAvailability.Checked;

            // Save the uploaded file
            string imagesFolder = Server.MapPath("~/Images/");
            if (!Directory.Exists(imagesFolder))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            string imagePath = "";
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                imagePath = "Images/" + fileName;
                fileUpload.SaveAs(Path.Combine(imagesFolder, fileName));
            }

            // Insert data into the database
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO cars (make, model, year, images, price, color, engine_type, transmission_type, hors_power, features, availability) " +
                               "VALUES (@Make, @Model, @Year, @Images, @Price, @Color, @EngineType, @TransmissionType, @HorsePower, @Features, @Availability)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Make", make);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Images", imagePath);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Color", color);
                    command.Parameters.AddWithValue("@EngineType", engineType);
                    command.Parameters.AddWithValue("@TransmissionType", transmissionType);
                    command.Parameters.AddWithValue("@HorsePower", horsePower);
                    command.Parameters.AddWithValue("@Features", features);
                    command.Parameters.AddWithValue("@Availability", availability);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        lblMessage.Text = "Car added successfully!";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Failed to add car!";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}
