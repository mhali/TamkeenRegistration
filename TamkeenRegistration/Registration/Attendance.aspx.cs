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
    public partial class Attendance : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

        }

        protected void txtAttendanceDate_TextChanged(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAttendanceByDate", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AttendanceDate", txtAttendanceDate.Text);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvAttendance.DataSource = dtbl;
            gvAttendance.DataBind();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            sqlDa = new SqlDataAdapter("GetAttendanceStatsByDate", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AttendanceDate", txtAttendanceDate.Text);
            DataTable dtblStats = new DataTable();
            sqlDa.Fill(dtblStats);
            sqlCon.Close();
            gvStats.DataSource = dtblStats;
            gvStats.DataBind();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            sqlDa = new SqlDataAdapter("GetAbsenceByDate", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@AttendanceDate", txtAttendanceDate.Text);
            DataTable dtblAbsence = new DataTable();
            sqlDa.Fill(dtblAbsence);
            sqlCon.Close();
            gvTamkeenerAbsence.DataSource = dtblAbsence;
            gvTamkeenerAbsence.DataBind();
        }
    }
}