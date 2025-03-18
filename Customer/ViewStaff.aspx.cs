using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Admin
{
    public partial class ViewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStaffDetails();
            }
        }
        private void LoadStaffDetails()
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            string query = "SELECT * FROM tbl_staff";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    reader.Close();
                }
            }
        }
    }
}