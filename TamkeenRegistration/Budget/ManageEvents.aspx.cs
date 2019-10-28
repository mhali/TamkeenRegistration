using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.Budget
{
    public partial class ManageEvents : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasBudgetAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            if (!IsPostBack)
            {
                btnEventDelete.Enabled = false;
                FillEventGridView();
            }
        }

        protected void btnEvent_Clear_Click(object sender, EventArgs e)
        {
            ClearEvent();
        }

        public void ClearEvent()
        {
            lblSuccessMessage.Text = lblErrorMessage.Text = "";
            txtEventId.Text = "";
            txtEventDate.Text = "";
            txtEventName.Text = "";
            btnEventSave.Text = "Save";
            btnEventDelete.Enabled = false;

        }
        protected void btnEvent_Save_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("EventCreateOrUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EventID", txtEventId.Text == "" ? 0 : Convert.ToInt32(txtEventId.Text));
            sqlCmd.Parameters.AddWithValue("@EventDate", txtEventDate.Text);
            sqlCmd.Parameters.AddWithValue("@EventName", txtEventName.Text);
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();

            ClearEvent();
            sqlCon.Close();
            FillEventGridView();

            if (noOfAffectedRecords  > 0)
                lblSuccessMessage.Text = "Saved Successfully";
            else
                lblErrorMessage.Text = "Unable to save";
        }
        protected void btnEvent_Delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("EventDelete", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EventID", Convert.ToInt32(txtEventId.Text));
            int noOfAffectedRecords = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearEvent();
            FillEventGridView();

            if (noOfAffectedRecords > 0)
                lblSuccessMessage.Text = "Deleted Successfully";
            else
                lblErrorMessage.Text = "Unable to delete";

        }

        void FillEventGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAllEvents", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvEvent.DataSource = dtbl;
            gvEvent.DataBind();
        }

        protected void EventLnk_OnClick(object sender, EventArgs e)
        {
            int EventID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            LoadEventInfo(EventID);
            FillEventDetailGridView(EventID);
        }

        void LoadEventInfo(int EventID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetOneEvent", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@EventID", EventID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            txtEventId.Text = dtbl.Rows[0]["EventID"].ToString();
            txtEventDate.Text = dtbl.Rows[0]["EventDate"].ToString();
            txtEventName.Text = dtbl.Rows[0]["EventName"].ToString();

            btnEventSave.Text = "Update";
            btnEventDelete.Enabled = true;
        }

        void FillEventDetailGridView(int EventID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetEventDetails", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@EventID", EventID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvEventDetail.DataSource = dtbl;
            gvEventDetail.DataBind();
        }

        protected void EventArchive_OnClick(object sender, EventArgs e)
        {
            int Event_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("EventArchiveByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@EventID", Event_ID);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            ClearEvent();
            FillEventGridView();
            if (noOfAffectedRows > 0)
                lblSuccessMessage.Text = "Archived Successfully";
            else
                lblErrorMessage.Text = "Unable to archive";

        }

    }
}