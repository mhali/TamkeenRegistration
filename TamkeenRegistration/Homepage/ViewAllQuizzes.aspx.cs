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
    public partial class ViewAllQuizzes : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillQuizGridView();
            }

        }

        void FillQuizGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetQuizzes", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvQuiz.DataSource = dtbl;
            gvQuiz.DataBind();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                if (dr["Photo"].ToString() == "")
                {
                    (e.Row.FindControl("Image1") as Image).ImageUrl = "";
                }
                else
                {
                    string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["Photo"]);
                    (e.Row.FindControl("Image1") as Image).ImageUrl = imageUrl;
                }
            }
        }

    }
}