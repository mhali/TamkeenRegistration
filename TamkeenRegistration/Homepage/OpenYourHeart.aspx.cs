using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;

namespace TamkeenRegistration.Homepage
{
    public partial class OpenYourHeart : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccessMessage.Text = lblErrorMessage.Text = "";

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AddOpenYourHeartMessage", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Name", txtName.Text);
            sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            sqlCmd.Parameters.AddWithValue("@Message", txtMessage.Text);

            if (sqlCmd.ExecuteNonQuery() > 0)
                lblSuccessMessage.Text = "Submitted Successfully";
            else
                lblSuccessMessage.Text = "Error! Please try again";

            sqlCon.Close();

            SendEmail();

            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Text = txtMessage.Text= txtEmail.Text = "";
        }

        private void SendEmail()
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("tamkeen.moderator@gmail.com", "Kimo4050");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("tamkeen.moderator@gmail.com");
            msg.To.Add(new MailAddress("m.h.ali@hotmail.com"));
            msg.To.Add(new MailAddress("tamkeen.moderator@gmail.com"));

            msg.Subject = "New open Your Heart Message";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>Open Your Heart Message</b><br/>"+ "<br/>Name:" +txtName.Text+ "<br/> Email:" + txtEmail.Text+ "<br/><br/> " + txtMessage.Text+"</body>");

            try
            {
                client.Send(msg);
                //lblMsg.Text = "Your message has been successfully sent.";
            }
            catch (Exception ex)
            {
                //lblMsg.ForeColor = Color.Red;
                //lblMsg.Text = "Error occured while sending your message." + ex.Message;
            }
        }
    }
}