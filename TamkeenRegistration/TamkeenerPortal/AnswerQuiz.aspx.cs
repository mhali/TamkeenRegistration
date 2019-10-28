using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace TamkeenRegistration.TamkeenerPortal
{
    public partial class AnswerQuiz : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasTamkeenerRights(Session))
            {
                throw new Exception("Non tamkeener type account");
            }

            if (!IsPostBack)
            {
                btnFSave.Text = "Save";
                txtAnswer.Enabled = true;
                lblMessage.Text = "";
                LoadQuizAnswer();
            }
        }

        protected void chkMentionName_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnFSave_Click(object sender, EventArgs e)
        {
            if (btnFSave.Text == "Edit")
            {

                btnFSave.Text = "Save";
                txtAnswer.Enabled = true;
                lblMessage.Text = "";
                return;
            }

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("AddQuizAnswer", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@UserName", Session["User"]);
            sqlCmd.Parameters.AddWithValue("@PublishName", chkMentionName.Checked);
            sqlCmd.Parameters.AddWithValue("@Answer", txtAnswer.Text);

            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            if (noOfAffectedRows > 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Saved Successfully";
                btnFSave.Text = "Edit";
                txtAnswer.Enabled = false;
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Unable to save";
            }
            sqlCon.Close();

        }



        private void LoadQuizAnswer()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("LoadQuizAnswer", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", Session["User"]);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count == 0)
            {
                return;
            }

            txtAnswer.Text = dtbl.Rows[0]["Answer"].ToString();
            chkMentionName.Checked = Convert.ToBoolean(dtbl.Rows[0]["PublishName"].ToString());

            btnFSave.Text = "Edit";
            txtAnswer.Enabled = false;
        }


    }
}