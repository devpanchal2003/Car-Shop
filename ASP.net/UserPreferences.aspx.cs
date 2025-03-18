    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.ASP.net
{
    public partial class UserPreferences : System.Web.UI.Page
    {
        private readonly string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO UserPreferences (UserName, Theme, Language, Gender, Address, PasswordHash) VALUES (@UserName, @Theme, @Language, @Gender, @Address, @PasswordHash)", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Theme", txtTheme.Text);
                cmd.Parameters.AddWithValue("@Language", txtLanguage.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text); // Note: You should hash the password before storing it in a real application
                cmd.ExecuteNonQuery();
            }
            ClearFields();
            BindGridView();
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserPreferences WHERE UserName = @UserName", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTheme.Text = reader["Theme"].ToString();
                    txtLanguage.Text = reader["Language"].ToString();
                    rblGender.SelectedValue = reader["Gender"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtPassword.Text = reader["PasswordHash"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE UserPreferences SET Theme = @Theme, Language = @Language, Gender = @Gender, Address = @Address, PasswordHash = @PasswordHash WHERE UserName = @UserName", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Theme", txtTheme.Text);
                cmd.Parameters.AddWithValue("@Language", txtLanguage.Text);
                cmd.Parameters.AddWithValue("@Gender", rblGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text); // Note: You should hash the password before storing it in a real application
                cmd.ExecuteNonQuery();
            }
            ClearFields();
            BindGridView();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM UserPreferences WHERE UserName = @UserName", con);
                cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                cmd.ExecuteNonQuery();
            }
            ClearFields();
            BindGridView();
        }

        private void BindGridView()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM UserPreferences", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvUserPreferences.DataSource = dt;
                gvUserPreferences.DataBind();
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = "";
            txtTheme.Text = "";
            txtLanguage.Text = "";
            rblGender.SelectedIndex = -1;
            txtAddress.Text = "";
            txtPassword.Text = "";
        }
    }
}