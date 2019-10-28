using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.TaskManagement
{
    public partial class MyWIs : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasAnyAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
                LoadWiStatus();
                LoadWIs();
                //FillDivisionGridView();
                //WiDiv.Visible = true;
            }
        }

        //void FillDivisionGridView()
        //{
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlDa = new SqlDataAdapter("DivisionsViewAll", sqlCon);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    sqlCon.Close();
        //    gvDivision.DataSource = dtbl;
        //    gvDivision.DataBind();
        //}

        //protected void DivisionLnk_OnClick(object sender, EventArgs e)
        //{
        //    int DivisionId = Convert.ToInt32((sender as LinkButton).CommandArgument);

        //    ClearCommitments();
        //    LoadCommitments(DivisionId);
        //}

        //private void ClearCommitments()
        //{
        //    gvCommitment.DataSource = null;
        //    gvCommitment.DataBind();
        //    ClearTasks();
        //}

        //private void ClearTasks()
        //{
        //    gvTask.DataSource = null;
        //    gvTask.DataBind();
        //    ClearWIs();
        //}

        //private void LoadCommitments(int DivisionId)
        //{
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlDa = new SqlDataAdapter("CommitmentsViewByDivisionID", sqlCon);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sqlDa.SelectCommand.Parameters.AddWithValue("@DivisionID", DivisionId);
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    sqlCon.Close();
        //    gvCommitment.DataSource = dtbl;
        //    gvCommitment.DataBind();
        //}

        //protected void CommitmentLnk_OnClick(object sender, EventArgs e)
        //{
        //    int CommitmentId = Convert.ToInt32((sender as LinkButton).CommandArgument);

        //    ClearTasks();
        //    LoadTasks(CommitmentId);
        //}

        //private void LoadTasks(int CommitmentId)
        //{
        //    if (sqlCon.State == ConnectionState.Closed)
        //        sqlCon.Open();
        //    SqlDataAdapter sqlDa = new SqlDataAdapter("TasksViewByCommitmentID", sqlCon);
        //    sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    sqlDa.SelectCommand.Parameters.AddWithValue("@CommitmentId", CommitmentId);
        //    DataTable dtbl = new DataTable();
        //    sqlDa.Fill(dtbl);
        //    sqlCon.Close();
        //    gvTask.DataSource = dtbl;
        //    gvTask.DataBind();
        //}


        protected void BoysTaskLnk_OnClick(object sender, EventArgs e)
        {
            int TaskId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            TaskLnk_OnClick('M', TaskId);
        }

        protected void GirlsTaskLnk_OnClick(object sender, EventArgs e)
        {
            int TaskId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            TaskLnk_OnClick('F', TaskId);
        }

        protected void WiLnk_OnClick(object sender, EventArgs e)
        {
            //int WiId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlDa = new SqlDataAdapter("WiViewByWiID", sqlCon);
            //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlDa.SelectCommand.Parameters.AddWithValue("@WiID", WiId);
            //DataTable dtbl = new DataTable();
            //sqlDa.Fill(dtbl);
            //sqlCon.Close();
            //if (dtbl.Rows.Count == 0)
            //{
            //    return;
            //}

            //txtWiId.Text = dtbl.Rows[0]["WiId"].ToString();
            //txtTaskId.Text = dtbl.Rows[0]["TaskId"].ToString();
            //txtWiName.Text = dtbl.Rows[0]["WiName"].ToString();
            //txtDesc.Text = dtbl.Rows[0]["WiDesc"].ToString();
            //txtDeadline.Text = dtbl.Rows[0]["DeadLine"].ToString();
            //txtDateCreated.Text = dtbl.Rows[0]["DateCreated"].ToString();
            //txtDateUpadted.Text = dtbl.Rows[0]["LastUpdated"].ToString();
            //txtDeadline.Text = dtbl.Rows[0]["DeadLine"].ToString();
            ////txtStatus.Text = dtbl.Rows[0]["StatusId"].ToString();
            //DropdownlistStatus.SelectedValue = dtbl.Rows[0]["StatusId"].ToString();
            //txtGender.Text = dtbl.Rows[0]["Gender"].ToString();

            //btnSave.Text = "Update";

            //WiDiv.Visible = true;
            //SetFocus(txtWiName);
        }

        protected void WiClose_OnClick(object sender, EventArgs e)
        {
            //if (!HasDivisionLeaderPermissions(lblCurrentGender.Text[0], Convert.ToInt32(lblCurrentTaskId.Text)))
            //{
            //    return;
            //}

            //int WiId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();


            //SqlCommand sqlCmd = new SqlCommand("CloseWi", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@WiId", WiId);
            //int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            //sqlCon.Close();

            //ClearWiDetais();
            //WiDiv.Visible = false;
            //LoadWIs(lblCurrentGender.Text[0], Convert.ToInt32(lblCurrentTaskId.Text));
        }



        //protected void btnAddNewWI_Click(object sender, EventArgs e)
        //{
        //    ClearWiDetais();
        //    btnSave.Text = "Save";
        //    SetFocus(txtWiName);
        //}

        private void ClearWiDetais()
        {
            //txtWiId.Text = "0";
            //txtTaskId.Text = lblCurrentTaskId.Text;
            //txtWiName.Text = "";
            //txtDesc.Text = "";
            //txtDateCreated.Text = "";
            //txtDateUpadted.Text = "";
            //txtDeadline.Text = "";
            //DropdownlistStatus.SelectedIndex = 0;
            //txtGender.Text = lblCurrentGender.Text;
            //WiDiv.Visible = true;
        }

        private void LoadWiStatus()
        {
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlDa = new SqlDataAdapter("GetWiStatus", sqlCon);
            //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            ////sqlDa.SelectCommand.Parameters.AddWithValue("@FamilyID", Family_ID);
            //DataTable dtbl = new DataTable();
            //sqlDa.Fill(dtbl);
            //sqlCon.Close();

            //DropdownlistStatus.DataSource = dtbl;
            //DropdownlistStatus.DataValueField = "StatusId";
            //DropdownlistStatus.DataTextField = "Status";
            //DropdownlistStatus.DataBind();
            //DropdownlistStatus.SelectedIndex = 0;


        }

        protected void btnSaveWI_Click(object sender, EventArgs e)
        {
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlCommand sqlCmd = new SqlCommand("AddOrUpdateWi", sqlCon);
            //sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@WiId", txtWiId.Text == "" ? 0 : Convert.ToInt32(txtWiId.Text));
            //sqlCmd.Parameters.AddWithValue("@TaskId", txtTaskId.Text);
            //sqlCmd.Parameters.AddWithValue("@WiName", txtWiName.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@WiDesc", txtDesc.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@Deadline", txtDeadline.Text.Trim());
            //sqlCmd.Parameters.AddWithValue("@StatusId", Convert.ToInt32(DropdownlistStatus.SelectedValue));
            ////sqlCmd.Parameters.AddWithValue("@StatusId", DropdownlistMainGuardian.SelectedValue == "" ? (int?)null : Convert.ToInt32(DropdownlistMainGuardian.SelectedValue));
            //sqlCmd.Parameters.AddWithValue("@Gender", txtGender.Text[0]);


            //int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
            //ClearWiDetais();
            //sqlCon.Close();
            //LoadWIs(lblCurrentGender.Text[0], Convert.ToInt32(lblCurrentTaskId.Text));

            ////if (noOfRecordsAffected > 0)
            ////    lblFSuccessMessage.Text = "Saved Successfully";
            ////else
            ////    lblFErrorMessage.Text = "Unable to save";

        }

        private void TaskLnk_OnClick(char Gender, int TaskId)
        {
            ClearWIs();
            if (!CheckUserPermissions(Gender, TaskId))
            {
                return;
            }
            LoadWIs();
        }

        private void ClearWIs()
        {
            //lblMessage.Text = "";
            //gvWi.DataSource = null;
            //gvWi.DataBind();
            //btnAddNew.Visible = false;
            //WiDiv.Visible = false;
        }

        private void LoadWIs()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("WiViewByUserName", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", SharedUtilities.GetCurrentUser(Session));
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvWi.DataSource = dtbl;
            gvWi.DataBind();
        }

        private bool CheckUserPermissions(char Gender, int TaskId)
        {
            //if (sqlCon.State == ConnectionState.Closed)
            //    sqlCon.Open();
            //SqlDataAdapter sqlDa = new SqlDataAdapter("CheckUserTaskPermission", sqlCon);
            //sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            //sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", SharedUtilities.GetCurrentUser(Session));
            //sqlDa.SelectCommand.Parameters.AddWithValue("@Gender", Gender);
            //sqlDa.SelectCommand.Parameters.AddWithValue("@TaskId", TaskId);
            //DataTable dtbl = new DataTable();
            //sqlDa.Fill(dtbl);
            //sqlCon.Close();

            //if (dtbl.Rows.Count == 0)
            //{
            //    lblMessage.Text = "Access Denied - no permission to view these workl items";
            //    return false;
            //}

            //lblMessage.Text = (Gender == 'M' ? "Boys" : "Girls") + " work items for this task:";
            //lblCurrentTaskId.Text = TaskId.ToString();
            //lblCurrentGender.Text = Gender.ToString();
            //btnAddNew.Visible = true;
            //if (HasDivisionLeaderPermissions(Gender, TaskId))
            //{
            //    txtDeadline.Enabled = true;
            //}
            //else
            //{
            //    txtDeadline.Enabled = false;
            //}

            return true;
        }

        private bool HasDivisionLeaderPermissions(char Gender, int TaskId)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("CheckDivisionLeaderTaskPermission", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", SharedUtilities.GetCurrentUser(Session));
            sqlDa.SelectCommand.Parameters.AddWithValue("@Gender", Gender);
            sqlDa.SelectCommand.Parameters.AddWithValue("@TaskId", TaskId);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            if (dtbl.Rows.Count == 0)
            {
                //lblMessage.Text = "Access Denied - no permission to view these workl items";
                return false;
            }

            //lblMessage.Text = (Gender == 'M' ? "Boys" : "Girls") + " work items for this task:";
            //lblCurrentTaskId.Text = TaskId.ToString();
            //lblCurrentGender.Text = Gender.ToString();
            //btnAddNew.Visible = true;
            return true;
        }


    }
}