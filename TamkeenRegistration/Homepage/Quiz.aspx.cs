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
    public partial class Quiz : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(SharedUtilities.SqlConnection);



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuiz();
            }
        }

        private void LoadQuiz()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("GetLastQuiz", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            if (dtbl.Rows.Count == 0)
            {
                return;
            }

            //            txtQuizId.Text = dtbl.Rows[0]["QuizId"].ToString();
            lblTitle.Text = dtbl.Rows[0]["title"].ToString();
            txtDesc.Text = dtbl.Rows[0]["Description"].ToString();

            string videoUrl = dtbl.Rows[0]["VideoUrl"].ToString();
            if (videoUrl != "")
            {
                frmVideo.Visible = true;
                frmVideo.Src = videoUrl;
            }
            else
            {
                frmVideo.Visible = false;
            }

            if (dtbl.Rows[0]["Photo"].ToString() != "")
            {
                imgPhoto.Visible = true;
                string strBase64 = Convert.ToBase64String((byte[])dtbl.Rows[0]["Photo"]);
                imgPhoto.ImageUrl = "data:Image/png;base64," + strBase64;
            }
            else
            {
                imgPhoto.Visible = false;
                imgPhoto.ImageUrl = "";
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.location.href='../TamkeenerPortal/AnswerQuiz.aspx'");
            Response.Write("</script>");
        }

        protected void btnAllQuizzes_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.location.href='ViewAllQuizzes.aspx'");
            Response.Write("</script>");
        }
        protected void btnPastQuizzes_Click(object sender, EventArgs e)
        {
            Response.Write("<script>");
            Response.Write("window.location.href='PastQuizzes.aspx'");
            Response.Write("</script>");
        }

  
    }
}