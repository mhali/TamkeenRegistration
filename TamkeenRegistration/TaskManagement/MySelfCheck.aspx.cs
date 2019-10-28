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
    public partial class MySelfCheck : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasAnyAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }


         
            lblWeek.Text="Check for the week of: " + GetPastStaurday().ToString("MM/dd/yyyy");

            LoadEvaluations();
        }

        private DateTime GetPastStaurday()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetPastSaturday", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            DateTime date = Convert.ToDateTime(dtbl.Rows[0]["PastStaurday"].ToString());

            return date;
        }

        private void LoadEvaluations()
        {
            string pastSaturday = GetPastStaurday().ToString("MM/dd/yyyy");



            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAdminEvaluationDimenion", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@UserName", SharedUtilities.GetCurrentUser(Session));
            sqlDa.SelectCommand.Parameters.AddWithValue("@EvaluationWeek", pastSaturday);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();

            if (dtbl.Rows.Count == 0)
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();

                SqlCommand sqlCmd = new SqlCommand("InsertAdminEvaluationDimenion", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserName", SharedUtilities.GetCurrentUser(Session));
                sqlCmd.Parameters.AddWithValue("@EvaluationWeek", pastSaturday);
                int noOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                LoadEvaluations();
                return;
            }


            gvSelfEvaluation.DataSource = dtbl;
            gvSelfEvaluation.DataBind();
        }
    }
}