using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop2024.Customer
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRequestOTP_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-LL5PFVT\\SQLEXPRESS;Initial Catalog=CARSHOP;Integrated Security=True";
            string email = Email.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Please enter your email.";
                return;
            }

            Session["Email"] = email;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string qry = "SELECT * FROM tbl_customer WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(qry, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        object count = cmd.ExecuteScalar();

                        if (count == null)
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "Email not registered.";
                        }
                        else
                        {
                            btnRequestOTP.Visible = false;
                            lblMessage.Visible = false;
                            string otp = OTPGenerator.GenerateOTP();
                            Session["expectedOTP"] = otp;
                            EmailSender.SendOTPEmail(email, otp);
                            lblMessage.Text = "OTP sent to your email. Please enter the OTP to verify.";
                            txtOTP.Visible = true;
                            btnVerifyOTP.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                txterror.Text = "Error: " + ex.Message;
            }
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            string expectedOTP = Session["expectedOTP"] as string;
            string enteredOTP = txtOTP.Text.Trim();

            if (enteredOTP == expectedOTP)
            {
                Response.Redirect("NewPassword.aspx");
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "Incorrect OTP. Please try again.";
            }
        }
    }

    public class OTPGenerator
    {
        public static string GenerateOTP(int length = 6)
        {
            const string validChars = "0123456789";
            char[] chars = new char[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[length];
                rng.GetBytes(bytes);
                for (int i = 0; i < length; i++)
                {
                    chars[i] = validChars[bytes[i] % validChars.Length];
                }
            }

            return new string(chars);
        }
    }

    public class EmailSender
    {
        public static void SendOTPEmail(string toEmail, string otp)
        {
            try
            {
                string senderEmail = "salonglamm00@gmail.com";
                string senderPassword = "mrwzytstenabewwc";

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(senderEmail);
                mail.To.Add(toEmail);
                mail.Subject = "OTP Verification";
                mail.Body = $"Your OTP for password recovery: {otp}";

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);

                HttpContext.Current.Response.Write("OTP sent successfully.");
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error sending email: " + ex.Message);
            }
        }
    }
}
