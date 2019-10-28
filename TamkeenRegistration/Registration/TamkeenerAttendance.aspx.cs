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
    public partial class TamkeenerAttendance : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            lblTamkeenerID.Text = Request.QueryString["TamkeenerId"];
            int Tamkeener_ID = Convert.ToInt32(lblTamkeenerID.Text);
            LoadAttendance(Tamkeener_ID);
            LoadEvents(Tamkeener_ID);
        }

        void LoadAttendance(int Tamkeener_ID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetAttendanceByTamkeener", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTamkeenerAttendance.DataSource = dtbl;
            gvTamkeenerAttendance.DataBind();
        }
        void LoadEvents(int Tamkeener_ID)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetBudgetItemDetailsByTamkeenerId", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTamkeenerEvents.DataSource = dtbl;
            gvTamkeenerEvents.DataBind();
        }


    }
}