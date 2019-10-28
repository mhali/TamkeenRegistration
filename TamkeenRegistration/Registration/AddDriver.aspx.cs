using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.Registration
{
    public partial class AddDriver : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        static List<int> TamkeenerIds = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            if (!IsPostBack)
            {
                FillDriverGridView();
                FillCheckedInTamkeenerGridView();
                FillCheckedOutTamkeenerGridView();
            }
        }

        void FillCheckedInTamkeenerGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllCheckedInTamkeeners", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvCheckedInTamkeener.DataSource = dtbl;
            gvCheckedInTamkeener.DataBind();

            TamkeenerIds = new List<int>();
            foreach (DataRow x in dtbl.Rows)
            {
                TamkeenerIds.Add(Convert.ToInt32(x[0]));
            }
        }

        void FillCheckedOutTamkeenerGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllCheckedOutTamkeeners", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvCheckedOutTamkeener.DataSource = dtbl;
            gvCheckedOutTamkeener.DataBind();
        }


        void FillDriverGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllDrivers", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvDriver.DataSource = dtbl;
            gvDriver.DataBind();
        }

        void FillTamkeenerPerDriverGridView()
        {
            string CurrentDriver = txtDriverName.Text;
            if (txtDriverName.Text.Trim() == "")
                return;

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetTamkeenersByDriver", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@DriverName", CurrentDriver);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTamkeenerPerDriver.DataSource = dtbl;
            gvTamkeenerPerDriver.DataBind();
        }

        protected void btnDriver_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            if (txtDriverName.Text.Trim() == "")
            {
                lblErrorMessage.Text = "Eror adding driver - driver name is empty.";
                return;
            }

            SqlCommand sqlCmd = new SqlCommand("AddDriver", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Phone", txtDriverPhone.Text.Trim() == "" ? (decimal?)null : Convert.ToDecimal(txtDriverPhone.Text.Trim()));
            sqlCmd.ExecuteNonQuery();

            ClearDriver();
            sqlCon.Close();
            FillDriverGridView();
            lblSuccessMessage.Text = "Driver added successfully";

        }

        protected void btnDriver_Delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            if (txtDriverName.Text.Trim() == "")
                return;

            SqlCommand sqlCmd = new SqlCommand("DeleteDriver", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text.Trim());
            sqlCmd.ExecuteNonQuery();

            ClearDriver();
            sqlCon.Close();
            FillDriverGridView();
            FillCheckedInTamkeenerGridView();
            FillCheckedOutTamkeenerGridView();
        }

        protected void btnDriver_Clear_Click(object sender, EventArgs e)
        {
            ClearDriver();
        }

        void ClearDriver()
        {
            txtDriverName.Text = txtDriverPhone.Text = "";
            gvTamkeenerPerDriver.DataSource = null;
            gvTamkeenerPerDriver.DataBind();

        }

        protected void DriverLnk_OnClick(object sender, EventArgs e)
        {
            string arguments = (sender as LinkButton).CommandArgument;
            string[] argumentList = arguments.Split(new char[] { ';' });
            txtDriverName.Text = argumentList[0];
            txtDriverPhone.Text = argumentList[1];
            FillTamkeenerPerDriverGridView();
        }

        protected void CheckOutTamkeener_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            CheckOutTamkeener(Tamkeener_ID);
        }

        void CheckOutTamkeener(int Tamkeener_ID)
        {
            if (!TamkeenerIds.Contains(Tamkeener_ID))
            {
                lblErrorMessage.Text = "You cannot check out a TAMKEENER who is not checked in";
                return;
            }

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("CheckOutTamkeener", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
            FillCheckedInTamkeenerGridView();
            FillCheckedOutTamkeenerGridView();
        }

        protected void SetDriver_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            SetDriver(Tamkeener_ID);
        }


        void SetDriver(int Tamkeener_ID)
        {
            if (!TamkeenerIds.Contains(Tamkeener_ID))
            {
                lblErrorMessage.Text = "You cannot assign a car to a TAMKEENER who is not checked in";
                return;
            }

            string CurrentDriver = txtDriverName.Text;
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("SetDriver", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            sqlCmd.Parameters.AddWithValue("@DriverName", CurrentDriver);
            sqlCmd.ExecuteNonQuery();

            sqlCon.Close();
            FillCheckedInTamkeenerGridView();
            FillCheckedOutTamkeenerGridView();
            FillTamkeenerPerDriverGridView();
        }

        protected void txtCheckOut_TextChanged(object sender, EventArgs e)
        {
            if (txtCheckOut.Text=="")
                return;
            int Tamkeener_ID = Convert.ToInt32(txtCheckOut.Text);
            CheckOutTamkeener(Tamkeener_ID);
            txtCheckOut.Text = "";
            txtCheckOut.Focus();
        }
        protected void txtSetDriver_TextChanged(object sender, EventArgs e)
        {
            if (txtSetDriver.Text == "")
                return;
            int Tamkeener_ID = Convert.ToInt32(txtSetDriver.Text);
            SetDriver(Tamkeener_ID);
            txtSetDriver.Text = "";
            txtSetDriver.Focus();
        }

    }
}