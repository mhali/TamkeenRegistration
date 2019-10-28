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
    public partial class QuizAnswers : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SharedUtilities.LoadFromCookies(Session, Request);

                if (!SharedUtilities.HasSocialMediaAdminRights(Session))
                {
                    throw new Exception("Non admin type account");
                }

                gvQuizAnswers.Columns[0].Visible = true;
            }

            catch (Exception ex)
            {
            }

            if (!IsPostBack)
            {
                

                FillQuizAnswerGridView(Request.QueryString["QuizId"]);
            }
        }

        void FillQuizAnswerGridView(string QuizId)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetQuizAnswersById", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@QuizId", QuizId);

            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvQuizAnswers.DataSource = dtbl;
            gvQuizAnswers.DataBind();
        }

    }
}