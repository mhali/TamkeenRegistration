using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace TamkeenRegistration.CreateUser
{
    public partial class CreateUser : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            lblLookUpErrorMessage.Text = lblLookUpSuccessMessage.Text = "";


            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("AddAccount", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@UserName", "saif-allah.nadeem");
            //string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile("saif54321", "SHA1");
            //sqlCmd.Parameters.AddWithValue("@Psswrd", hashedPassword);
            //int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();


            //< user name = "Safwan" password = "Safwan3060" />


            //   < user name = "Habiba" password = "Habiba2030" />


            //      < user name = "Nayyra" password = "Nayyra4050" />


            //         < user name = "Laila" password = "Laila6010" />


            //            < user name = "Rawan" password = "Rawan6010" />
            //        < user name = "OmarA" password = "OmarA5090" />

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlCommand cmd;
                if (lstAccountType.SelectedIndex == 1)
                {
                    cmd = new SqlCommand("spRegisterUser", sqlCon);
                }
                else
                {
                    cmd = new SqlCommand("spRegisterTamkeener", sqlCon);
                }

                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@UserName", txtUserName.Text);
                // FormsAuthentication calss is in System.Web.Security namespace
                string encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text, "SHA1");
                SqlParameter password = new SqlParameter("@Password", encryptedPassword);
                SqlParameter email = new SqlParameter("@Email", txtEmail.Text);
                SqlParameter familyId = new SqlParameter("@FamilyID", txtFamilyLookupId.Text);
                SqlParameter passCode = new SqlParameter("@PassCode", txtFamilyPassCode.Text);

                cmd.Parameters.Add(username);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(email);
                cmd.Parameters.Add(familyId);
                cmd.Parameters.Add(passCode);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                int ReturnCode = (int)cmd.ExecuteScalar();
                if (ReturnCode == -1)
                {
                    lblMessage.Text = "User Name already in use, please choose another user name";
                }
                else if (ReturnCode == -2)
                {
                    lblMessage.Text = "Invalid Username and Passcode";
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
                sqlCon.Close();
            }
        }

        protected void lstAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFamilyLookupId.Enabled = true;
            txtFamilyPassCode.Enabled = true;
            btnQuickLookup.Enabled = true;
            tbleFamily.Visible = false;
            tblfamilyPassCode.Visible = false;
            accountDetails.Visible = false;

            if (lstAccountType.SelectedIndex == 0)
            {
               
                lblLookUpErrorMessage.Text = lblLookUpSuccessMessage.Text = "";
            }
            else if (lstAccountType.SelectedIndex == 1)
            {
                lblId.Text = "Family ID";
                tblfamilyPassCode.Visible = true;
                //accountDetails.Visible = true;
            }
            else if (lstAccountType.SelectedIndex == 2)
            {
                lblId.Text = "Tamkeener ID";
                tblfamilyPassCode.Visible = true;
                //accountDetails.Visible = true;
            }
        }


        protected void btnQuickLookup_Click(object sender, EventArgs e)
        {
            tbleFamily.Visible = false;
            accountDetails.Visible = false;
            if (txtFamilyLookupId.Text == "")
                return;

            int Family_ID = Convert.ToInt32(txtFamilyLookupId.Text);
            if (Family_ID == 0)
            {
                lblLookUpErrorMessage.Text = "Family info not found";
                return;
            }

            if (txtFamilyPassCode.Text == "")
            {
                lblLookUpErrorMessage.Text = "Invalid Passcode";
                return;
            }

            int PassCode = Convert.ToInt32(txtFamilyPassCode.Text);
            if (PassCode == 0)
            {
                lblLookUpErrorMessage.Text = "Invalid Passcode";
                return;
            }

            if (lstAccountType.SelectedIndex == 1)
            {
                int Guardian_ID = LoadFamilyInfo(Family_ID, PassCode);
                if (Guardian_ID < 0)
                {
                    lblLookUpErrorMessage.Text = "Unable to load family info";
                    lblLookUpSuccessMessage.Text = "";
                    return;
                }

                lblLookUpSuccessMessage.Text = "Family info loaded successfully";
                lblLookUpErrorMessage.Text = "";
                tbleFamily.Visible = true;
                accountDetails.Visible = true;
                txtFamilyLookupId.Focus();
            }
            else if (lstAccountType.SelectedIndex == 2)
            {
                int returnCode = LoadTamkeenerInfo(Family_ID, PassCode);
                if (returnCode <= 0)
                {
                    lblLookUpErrorMessage.Text = "Unable to load tamkeener info";
                    lblLookUpSuccessMessage.Text = "";
                    return;
                }

                lblLookUpSuccessMessage.Text = "Tamkeener info loaded successfully";
                lblLookUpErrorMessage.Text = "";
                tbleFamily.Visible = true;
                accountDetails.Visible = true;
                txtFamilyLookupId.Focus();

            }

            txtFamilyLookupId.Enabled = false;
            txtFamilyPassCode.Enabled = false;
            btnQuickLookup.Enabled = false;
        }

        int LoadFamilyInfo(int Family_ID, int PassCode)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("FamilyViewByID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@FamilyID", Family_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count!=1)
            {
                lblLookUpErrorMessage.Text = "Incorrect Passcode";
                return -1;
            }

            txtFamilyName.Text = dtbl.Rows[0]["FamilyName"].ToString();
            txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtUserName.Text = dtbl.Rows[0]["UserName"].ToString();
            if (PassCode != Convert.ToInt32(dtbl.Rows[0]["PassCode"]))
            {
                lblLookUpErrorMessage.Text = "Incorrect Passcode";
                return -1;
            }
            return dtbl.Rows[0]["MainGuardian"].ToString() == "" ? 0 : int.Parse(dtbl.Rows[0]["MainGuardian"].ToString());
        }

        int LoadTamkeenerInfo(int Tamkeener_ID, int PassCode)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TamkeenerViewByTamkeenerID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count != 1)
            {
                lblLookUpErrorMessage.Text = "Incorrect Passcode";
                return -1;
            }

            txtFamilyName.Text = dtbl.Rows[0]["FirstName"].ToString() +" "+ dtbl.Rows[0]["LastName"].ToString();
            txtEmail.Text = dtbl.Rows[0]["Email"].ToString();
            txtUserName.Text = dtbl.Rows[0]["UserName"].ToString();
            if (PassCode != Convert.ToInt32(dtbl.Rows[0]["PassCode"]))
            {
                lblLookUpErrorMessage.Text = "Incorrect Passcode";
                return -1;
            }
            return 1;
        }
    }
}