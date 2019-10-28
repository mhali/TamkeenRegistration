using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace TamkeenRegistration.Homepage
{
    public partial class DefaultSubrame : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadVLastTwoideo();
            }
        }

        private void LoadVLastTwoideo()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetLastTwoVideos", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count != 2)
            {
                return;
            }

            suggestedVideo1.Src = dtbl.Rows[0]["VideoUrl"].ToString();
            lblsuggestedVideo1.Text = dtbl.Rows[0]["Caption"].ToString();
            suggestedVideo2.Src = dtbl.Rows[1]["VideoUrl"].ToString();
            lblsuggestedVideo2.Text = dtbl.Rows[1]["Caption"].ToString();

        }
    }
}