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
    public partial class TamkeenerUnarchive : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            SharedUtilities.LoadFromCookies(Session, Request);

            if (!SharedUtilities.HasRegistrationAdminRights(Session))
            {
                throw new Exception("Non admin type account");
            }

            if (!IsPostBack)
            {
                FillTamkeenerGridView();
            }
        }

        private void FillTamkeenerGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TamkeenerViewArchived", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvTamkeener.DataSource = dtbl;
            gvTamkeener.DataBind();
        }
       protected void TamkeenerUnArchive_OnClick(object sender, EventArgs e)
        {
            int Tamkeener_ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TamkeenerUnArchiveByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@TamkeenerID", Tamkeener_ID);
            int noOfAffectedRows = sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            FillTamkeenerGridView();
        }

    }
}