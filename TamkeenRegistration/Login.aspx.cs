using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration
{
    public partial class Login : System.Web.UI.Page
    {
//        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            //FormsAuthentication.SignOut();
            lblLoginError.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Authenticate againts the list stored in web.config
            //if (FormsAuthentication.Authenticate(txtUserName.Text, txtPassword.Text))
            if (AuthenticateUser(txtUserName.Text, txtPassword.Text))
            {
                 // Create the authentication cookie and redirect the user to welcome page
                   
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
            }
            else
            {
                lblLoginError.Text = "Invalid UserName and/or password";
            }

        }


        private bool AutheticateOldUser(string userName, string password)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("spAuthenticateOldUser", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", userName);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            if (dtbl.Rows.Count != 1)
            {                
                return false;
            }

            string Salt= dtbl.Rows[0]["salt"].ToString();
            string PasswordHash= dtbl.Rows[0]["password"].ToString();

            return SharedUtilities.AutheticateOldCredentials(Salt, PasswordHash, password);
        }

        private void MigrateOldUser(string userName, string encryptedPassword)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("spMigrateOldUser", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@UserName", userName);
            sqlCmd.Parameters.AddWithValue("@Password", encryptedPassword);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        private bool AuthenticateUser(string userName, string password)
        {
            string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("spAuthenticateUser", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", userName);
            sqlDa.SelectCommand.Parameters.AddWithValue("@Password", encryptedPassword);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            if (dtbl.Rows.Count != 1)
            {
                //if (AutheticateOldUser(userName, password))
                //{
                //    MigrateOldUser(userName, encryptedPassword);
                //    return AuthenticateUser(userName, password);
                //}

                return false;
            }

            Session["User"] = userName;
            Session["AccountType"] = dtbl.Rows[0]["AccountType"].ToString();
            Session["ID"] = dtbl.Rows[0]["ID"].ToString();
            Session["IsAdmin"] = dtbl.Rows[0]["IsAdmin"].ToString();
            Session["IsSocialMediaAdmin"] = dtbl.Rows[0]["IsSocialMediaAdmin"].ToString();
            Session["IsRegistrationAdmin"] = dtbl.Rows[0]["IsRegistrationAdmin"].ToString();
            Session["IsBudgetAdmin"] = dtbl.Rows[0]["IsBudgetAdmin"].ToString();
            Session["IsSubBudgetAdmin"] = dtbl.Rows[0]["IsSubBudgetAdmin"].ToString();
            Session["IsTaskManagementAdmin"] = dtbl.Rows[0]["IsTaskManagementAdmin"].ToString();
            Session["NickName"] = dtbl.Rows[0]["NickName"].ToString();

            Response.Cookies["User"].Value = userName;
            Response.Cookies["AccountType"].Value = dtbl.Rows[0]["AccountType"].ToString();
            Response.Cookies["ID"].Value = dtbl.Rows[0]["ID"].ToString();
            Response.Cookies["IsAdmin"].Value = dtbl.Rows[0]["IsAdmin"].ToString();
            Response.Cookies["IsSocialMediaAdmin"].Value = dtbl.Rows[0]["IsSocialMediaAdmin"].ToString();
            Response.Cookies["IsRegistrationAdmin"].Value = dtbl.Rows[0]["IsRegistrationAdmin"].ToString();
            Response.Cookies["IsBudgetAdmin"].Value = dtbl.Rows[0]["IsBudgetAdmin"].ToString();
            Response.Cookies["IsSubBudgetAdmin"].Value = dtbl.Rows[0]["IsSubBudgetAdmin"].ToString();
            Response.Cookies["IsTaskManagementAdmin"].Value = dtbl.Rows[0]["IsTaskManagementAdmin"].ToString();
            Response.Cookies["NickName"].Value = dtbl.Rows[0]["NickName"].ToString();

            return true;

           
        }

    }
}